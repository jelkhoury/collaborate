import { Inject, Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { ChatGroupSummary, ChatGroupHistory } from '../shared/models';
import { Observable } from 'rxjs/Observable';
import { Http, Headers } from '@angular/http';
import { AuthenticationService } from '../services/authentication.service';
import 'expose-loader?jQuery!jquery';
import 'expose-loader?$!jquery';
import * as $ from 'jquery';
import 'ms-signalr-client';
import 'rxjs/Rx';

@Injectable()
export class ChatService {
    private connection: any;
    private chatHub: any;

    // events sources
    private connectionStartedSource = new Subject<string>();
    private messageReceivedSource = new Subject<string>();
    // events
    public connectionStarted$ = this.connectionStartedSource.asObservable();
    public messageReceived$ = this.messageReceivedSource.asObservable();

    constructor(private authenticationService: AuthenticationService, @Inject('API_URL') private apiUrl: string, private http: Http) {
        console.log('constructor');
        this.connection = $.hubConnection(this.apiUrl);
        this.connection.logging = true;

        var self = this;
        this.chatHub = this.connection.createHubProxy('ChatHub');
        this.chatHub.on('messageReceived', function (message) {
            this.sendAck(message.DestinationId, message.Id);
            self.messageReceivedSource.next(message);
        });

        this.connection.connectionSlow(function () {
            console.log("connectionSlow");
        });

        this.connection.reconnecting(function () {
            console.log("reconnecting");
        });

        this.connection.reconnected(function () {
            console.log("reconnected");
        });

        this.connection.disconnected(function () {
            console.log("disconnected");
        });
    }

    /**
     * start connection and return connection id
     */
    start(): Observable<string> {
        var self = this;
        $.signalR.ajaxDefaults.headers = { Authorization: "Bearer " + this.authenticationService.getAccessToken() };

        var result: Observable<string> = Observable.create(observer => {
            console.log($.signalR.connectionState);
            //if ($.signalR.connectionState == SignalRConnectionState.disconnected) {
                this.connection.start()
                    .done(function () {
                        observer.next(self.connection.id);
                        observer.complete();
                        self.connectionStartedSource.next(self.connection.id);
                    })
                    .fail(function (e) {
                        observer.error(e);
                        observer.complete();
                        console.log(e);
                        self.connectionStartedSource.error(e);
                    });
            //}
        });

        return result;
    }
    register(): Observable<void> {
        var self = this;

        var result: Observable<void> = Observable.create(observer => {
            this.chatHub.invoke('register')
                .done(function () {
                    observer.next(self.connection.id);
                    console.log('registered');
                })
                .fail(function (e) {
                    observer.error(e);
                    console.log(e);
                })
                .then(() => {
                    observer.complete();
                });
        });

        return result;
    }
    /**
     * stop the connection to the SignalR server
     */
    stop() {
        // TODO : stop the connection
    }
    /**
     * send text message to destination (Group for now)
     * @param destinationId : group id
     * @param message : the message content
     */
    sendTextMessage(destinationId: number, message: string) {
        // TODO : return message id
        var clientMessage = {
            destinationId: destinationId,
            body: message,
            clientSentDate: new Date()
        };

        this.chatHub.invoke('sendMessage', clientMessage)
            .done(r => {

            });
    }
    sendAck(destinationId: number, messageId: number) {
        var ackMessage = {
            destinationId: destinationId,
            messageId: messageId,
        };

        this.chatHub.invoke('ackMessage', ackMessage)
            .done(r => {

            });
    }
    /**
     * get all groups with number of unread messages (unread by the current user)
     */
    getGroupsSummary(): Observable<ChatGroupSummary[]> {
        var url = this.apiUrl + '/api/chat/groups/summary';

        var requestArgs = {
            headers: new Headers()
        };
        requestArgs.headers.append("Authorization", "Bearer " + this.authenticationService.getAccessToken());
        return Observable.create(observer => {
            this.http.get(url, requestArgs).map(g => g.json() as ChatGroupSummary[]).subscribe(g => {
                observer.next(g);
                observer.complete();
            });
        });
    }
    /**
     * Get group name and history for the last 2 days
     * @param groupId : id of the group
     */
    getGroupHistory(groupId: number): Observable<ChatGroupHistory> {
        return Observable.create(observer => {
            //    this.http.post(url, { Username: username, Password: password }).map(res => res.json() as User).subscribe(u => {
            //        if (u) {
            //            localStorage.setItem("currentUser", username);
            //            this.userLoggedInSource.next(username);
            //        }

            observer.next(
                {
                    id: groupId,
                    name: 'SABIS IT',
                    members: ['jek', 'hri', 'egh'],
                    messages: [
                        {
                            id: 1,
                            sender: 'jek',
                            text: 'Welcome to lebanon',
                            dateSent: new Date()
                        }]
                });
            //call complete if you want to close this stream (like a promise)
            observer.complete();
            //    });
        });
    }
}

enum SignalRConnectionState {
    connecting = 0,
    connected = 1,
    reconnecting = 2,
    disconnected = 4
}
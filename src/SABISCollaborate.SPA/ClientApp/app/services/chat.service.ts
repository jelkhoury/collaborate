import { Inject, Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { ChatGroupSummary, ChatGroupHistory } from '../shared/models';
import { Observable } from 'rxjs/Observable';
import { Http } from '@angular/http';
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
    //private onErrorSource = new Subject<any>();
    // events
    public connectionStarted$ = this.connectionStartedSource.asObservable();
    //public onError$ = this.onErrorSource.asObservable();

    constructor(private authenticationService: AuthenticationService, @Inject('API_URL') private apiUrl: string, private http: Http) {
        this.connection = $.hubConnection(this.apiUrl);
        $.signalR.ajaxDefaults.headers = { Authorization: "Bearer " + this.authenticationService.getAccessToken() };
        this.chatHub = this.connection.createHubProxy('ChatHub');
        this.connection.logging = true;
    }

    // chat Hub operations
    start(): Observable<string> {
        var self = this;
        return Observable.create(observer => {
            // TODO : check if not started
            this.connection.start()
                .done(function () {
                    observer.next(self.connection.id);
                    observer.complete();
                    self.connectionStartedSource.next(self.connection.id);
                })
                .fail(function (e) {
                    observer.error(e);
                    observer.complete();
                    self.connectionStartedSource.error(e);
                });
        });
    }
    stop() {
        // TODO : stop the connection
    }
    register(): Observable<void> {
        this.chatHub.on('messageReceived', function (message) {
            console.log(message);
        });

        return Observable.create(observer => {
            this.chatHub.invoke('register')
                .done(() => {
                    console.log('registered');
                    observer.next();
                    observer.complete();
                })
                .fail(e => {
                    console.log(e);
                    observer.error(e);
                    observer.complete();
                });
        });
    }
    sendTextMessage(destinationId: number, message: string) {
        var clientMessage = {
            destinationId: destinationId,
            body: message,
            clientSentDate: new Date()
        };

        this.chatHub.invoke('sendMessage', clientMessage)
            .done(r => {

            });
    }
    // end chat Hub operations
    /**
     * get all groups with number of unread messages (unread by the current user)
     */
    getGroupsWithSummary(): Observable<ChatGroupSummary[]> {
        var url = this.apiUrl + '/api/chat/groups/summary';

        return Observable.create(observer => {
            this.http.get(url).map(g => g.json() as ChatGroupSummary[]).subscribe(g => {
                observer.next(g);
                observer.complete();
            });
        });
    }

    getGroupHistory(groupId: number): Observable<ChatGroupHistory> {
        return Observable.create(observer => {
            //    this.http.post(url, { Username: username, Password: password }).map(res => res.json() as User).subscribe(u => {
            //        if (u) {
            //            localStorage.setItem("currentUser", username);
            //            this.userLoggedInSource.next(username);
            //        }

            observer.next(
                {
                    id: 1,
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
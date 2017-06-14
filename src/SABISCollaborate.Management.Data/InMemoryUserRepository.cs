using SABISCollaborate.Registration.Core.Model;
using SABISCollaborate.Registration.Core.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SABISCollaborate.Registration.Data
{
    public class InMemoryUserRepository : IUserRepository
    {
        #region Fields
        private List<User> _users;
        private string _tempFolderPath = @"c:\DeleteLater";
        private string _picturesFolderPath = @"c:\ProfilePictures";
        #endregion

        #region ctor
        public InMemoryUserRepository()
        {
            this._users = new List<User>();
            //65124356-346e-40d8-a4aa-bde62c1f56b3
            UserProfile profile = new UserProfile("jek", "Joseph", "El Khoury", DateTime.Now);
            profile.PictureId = "65124356-346e-40d8-a4aa-bde62c1f56b3";
            this.SaveUser(new User(1, "jek", "1", "joseph.elkhoury@outlook.com", profile));
            this.SaveUser(new User(2, "hri", "1", "hrizk@outlook.com", new UserProfile("hri", "Hiba", "Rizk", DateTime.Now)));
            this.SaveUser(new User(3, "egh", "1", "eghazal@outlook.com", new UserProfile("egh", "Elie", "Ghazal", DateTime.Now)));
            this.SaveUser(new User(4, "rbr", "1", "ralphbouraad@outlook.com", new UserProfile("rbr", "Ralph", "Bou Raad", DateTime.Now)));
            this.SaveUser(new User(5, "gma", "1", "gmantoufeh@outlook.com", new UserProfile("manatifo", "Georges", "Mantoufeh", DateTime.Now)));
        }
        #endregion

        #region Users
        public void CommitProfilePicture(string id)
        {
            string source = Path.Combine(this._tempFolderPath, $"{id}.jpg");
            string destination = Path.Combine(this._picturesFolderPath, $"{id}.jpg");

            if (!File.Exists(source))
            {
                throw new ArgumentOutOfRangeException($"temp profile picture of id {id} is not available");
            }

            File.Move(source, destination);
        }

        public List<User> GetAll()
        {
            return this._users;
        }

        public byte[] GetProfilePicture(string id)
        {
            string filePath = Path.Combine(this._picturesFolderPath, $"{id}.jpg");
            if (System.IO.File.Exists(filePath))
            {
                Byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                return fileBytes;
            }

            return null;
        }

        public byte[] GetTempProfilePicture(string id)
        {
            string filePath = Path.Combine(this._tempFolderPath, $"{id}.jpg");
            if (System.IO.File.Exists(filePath))
            {
                Byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                return fileBytes;
            }

            return null;
        }

        public User GetUser(int userId)
        {
            return this._users.Find(u => u.Id == userId);
        }

        public User GetUserByUsernameOrEmail(string username, string email)
        {
            return this._users.Find(u => String.Compare(u.Username, username, true) == 0
             || String.Compare(u.IdentifierEmail, email, true) == 0);
        }

        public void SaveTempProfilePicture(string id, byte[] bytes)
        {
            string filePath = Path.Combine(this._tempFolderPath, $"{id}.jpg"); //Path.GetTempFileName();
            using (FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                stream.Write(bytes, 0, bytes.Count());
            }
        }

        public void SaveUser(User user)
        {
            User result = this.GetUser(user.Id);

            int newId = 1;

            // remove old user
            if (result != null)
            {
                newId = result.Id;
                this._users.Remove(result);
            }
            else if (this._users.Count > 0)
            {
                newId = this._users.Max(u => u.Id);
            }

            // create new user with id
            result = new User(newId, user.Username, user.PasswordHash, user.IdentifierEmail, user.Profile);

            this._users.Add(result);
        }

        public UserProfile UpdateProfile(int userId, UserProfile profile)
        {
            return profile;
        }
        #endregion

    }
}

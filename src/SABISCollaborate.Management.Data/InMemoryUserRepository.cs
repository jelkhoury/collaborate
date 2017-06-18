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
        private Dictionary<string, byte[]> _tempImages = new Dictionary<string, byte[]>();
        private Dictionary<string, byte[]> _profilePictures = new Dictionary<string, byte[]>();
        //private string _tempFolderPath = @"c:\DeleteLater";
        //private string _picturesFolderPath = @"c:\ProfilePictures";
        #endregion

        #region ctor
        public InMemoryUserRepository()
        {
            this._users = new List<User>();

            // Jek
            UserProfile profile = new UserProfile("jek", "Joseph", "El Khoury", DateTime.Now);
            profile.PictureId = "65124356-346e-40d8-a4aa-bde62c1f56b3";
            this.SaveUser(new User(1, "jek", "a+b=*1*b+a", "joseph.elkhoury@outlook.com", profile));

            // Hri
            profile = new UserProfile("hri", "Hiba", "Rizk", DateTime.Now);
            profile.PictureId = "95124356-346e-40d8-a4aa-bde62c1f56b4";
            this.SaveUser(new User(2, "hri", "a+b=*1*b+a", "hrizk@outlook.com", new UserProfile("hri", "Hiba", "Rizk", DateTime.Now)));

            // Egh
            profile = new UserProfile("egh", "Elie", "Ghazal", DateTime.Now);
            profile.PictureId = "85124356-346e-40d8-a4aa-bde62c1f56b4";
            this.SaveUser(new User(3, "egh", "a+b=*1*b+a", "eghazal@outlook.com", profile));

            this.SaveUser(new User(4, "rbr", "a+b=*1*b+a", "ralphbouraad@outlook.com", new UserProfile("rbr", "Ralph", "Bou Raad", DateTime.Now)));
            this.SaveUser(new User(5, "gma", "a+b=*1*b+a", "gmantoufeh@outlook.com", new UserProfile("manatifo", "Georges", "Mantoufeh", DateTime.Now)));

            // Karine
            profile = new UserProfile("karine", "Karine", "Bedran", DateTime.Now);
            profile.PictureId = "75124356-346e-40d8-a4aa-bde62c1f56b4";
            this.SaveUser(new User(6, "admin", "a+b=*admin*b+a", "karine.bedran@sabis.net", profile));

            this._profilePictures.Add("65124356-346e-40d8-a4aa-bde62c1f56b3", StaticProfilePictures.Jek);
            this._profilePictures.Add("75124356-346e-40d8-a4aa-bde62c1f56b4", StaticProfilePictures.Karine);
            this._profilePictures.Add("85124356-346e-40d8-a4aa-bde62c1f56b4", StaticProfilePictures.Egh);
            this._profilePictures.Add("95124356-346e-40d8-a4aa-bde62c1f56b4", StaticProfilePictures.Hri);
        }
        #endregion

        #region Users
        public void CommitProfilePicture(string id)
        {
            //string source = Path.Combine(this._tempFolderPath, $"{id}.jpg");
            //string destination = Path.Combine(this._picturesFolderPath, $"{id}.jpg");

            //if (!File.Exists(source))
            //{
            //    throw new ArgumentOutOfRangeException($"temp profile picture of id {id} is not available");
            //}

            //File.Move(source, destination);

            byte[] imageBytes = null;
            if (this._tempImages.TryGetValue(id, out imageBytes))
            {
                this._profilePictures.Add(id, imageBytes);
            }
        }

        public List<User> GetAll()
        {
            return this._users;
        }

        public byte[] GetProfilePicture(string id)
        {
            //string filePath = Path.Combine(this._picturesFolderPath, $"{id}.jpg");
            //if (System.IO.File.Exists(filePath))
            //{
            //    Byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            //    return fileBytes;
            //}

            byte[] imageBytes = null;
            if (this._profilePictures.TryGetValue(id, out imageBytes))
            {
                return imageBytes;
            }

            return null;
        }

        public byte[] GetTempProfilePicture(string id)
        {
            //string filePath = Path.Combine(this._tempFolderPath, $"{id}.jpg");
            //if (System.IO.File.Exists(filePath))
            //{
            //    Byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            //    return fileBytes;
            //}

            byte[] imageBytes = null;
            if (this._tempImages.TryGetValue(id, out imageBytes))
            {
                return imageBytes;
            }

            return null;
        }

        public User GetUser(int userId)
        {
            return this._users.Find(u => u.Id == userId);
        }

        public User GetUser(string username, string passwordHash)
        {
            return this._users.FirstOrDefault(u => u.Username.Trim().ToLower() == username.Trim().ToLower() && u.PasswordHash == passwordHash);
        }

        public User GetUserByUsernameOrEmail(string username, string email)
        {
            return this._users.Find(u => String.Compare(u.Username, username, true) == 0
             || String.Compare(u.IdentifierEmail, email, true) == 0);
        }

        public List<User> GetUsers(string searchText)
        {
            string text = searchText.ToLower().Trim();

            return this._users.Where(u =>
            {
                return u.IdentifierEmail.ToLower().Contains(text)
                || u.IdentifierEmail.ToLower().Contains(text)
                || u.Username.ToLower().Contains(text)
                || u.Profile.FirstName.ToLower().Contains(text)
                || u.Profile.LastName.ToLower().Contains(text)
                || u.Profile.Nickname.ToLower().Contains(text);
            }).ToList();
        }

        public void SaveTempProfilePicture(string id, byte[] bytes)
        {
            //string filePath = Path.Combine(this._tempFolderPath, $"{id}.jpg"); //Path.GetTempFileName();
            //using (FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate))
            //{
            //    stream.Write(bytes, 0, bytes.Count());
            //}

            this._tempImages.Add(id, bytes);
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

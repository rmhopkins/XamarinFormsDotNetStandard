using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ProfilesDemo.Models;
using System.Diagnostics;
using System;

namespace ProfilesDemo.Services
{
    public class AzureDataService
    {
        static IMobileServiceSyncTable<Profile> profileTable;
        static AzureDataService defaultInstance = new AzureDataService();
        MobileServiceClient client;

        public static AzureDataService DefaultInstance
        {
            get { return defaultInstance; }
            private set { defaultInstance = value; }
        }

        public MobileServiceClient Client
        {
            get { return client; }
        }

        public async void Initialize()
        {
            client = new MobileServiceClient("https://xamarindemoapps.azurewebsites.net");

            var path = "syncstore.db";
            var store = new MobileServiceSQLiteStore(path);

            store.DefineTable<Profile>();

            await Client.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());
            profileTable = client.GetSyncTable<Profile>();

            return;
        }

        public async Task<ObservableCollection<Profile>> GetAllProfilesAsync()
        {
            await SyncProfilesAsync();

            if (profileTable == null)
                profileTable = DefaultInstance.Client.GetSyncTable<Profile>();

            IEnumerable<Profile> profiles = await profileTable.ToEnumerableAsync();

            return new ObservableCollection<Profile>(profiles);
        }

        public async Task<bool> SyncProfilesAsync()
        {
            if (profileTable == null)
                profileTable = DefaultInstance.Client.GetSyncTable<Profile>();
            
            try
            {
                await profileTable.PullAsync("allprofiles", profileTable.CreateQuery());
            }
            catch (Exception e)
            {
                Debug.WriteLine("Could not sync Profile table.  " + e.Message);
            }

            // Uncomment if editing/writing to the DB is added
            //await Client.SyncContext.PushAsync();

            return true;
           
        }
    }
}

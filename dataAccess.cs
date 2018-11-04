using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Configuration;
using Dapper;

/**
 *  1. db-Datei ins C# Projekt einbinden
 *  2. NUGET-Packete Installieren (Dapper, SQLite-Core, System.Configuration)
 *  3. App.Config dies hinzufügen:
 *      <connectionStrings>
 *          <add name="Default" connectionString="Data Source=.\db.db;Version=3;" providerName="System.data.SqlClient"/>
 *       </connectionStrings>
 *  4. Planet-Klasse & Satellite-Klasse in eigene .cs-Dateien tun
 **/

namespace WpfApp1
{
    public interface IDataholdings {

        List<Planet> GetAllPlanets();
        List<Satellite> GetAllSatellites(int planet_id);

        Planet GetIndividualPlanet(Planet planet);
        Satellite GetIndividualSatellite(Satellite satellite);

        void SavePlanet(Planet planet);
        void SaveSatellite(Satellite satellite);

        void UpdatePlanet(Planet planet);
        void UpdateSatellite(Satellite satellite);

        void DeletePlanet(Planet planet);
        void DeleteSatelite(Satellite satellite);
    }

    public class Planet
    {
        public string planet_Name;
        public int planet_ID;
    }
    public class Satellite
    {
        public string satellite_Name;
        public int satellite_ID;
        public int planet_ID;
    }

    public class dataAccess : IDataholdings
    {
        public static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public List<Planet> GetAllPlanets()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Planet>("select * from Planets", new DynamicParameters());
                return output.ToList();
            }
        }

        public List<Satellite> GetAllSatellites(int planet_id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Satellite>("select * from Satellites where planet_ID = @planet_id", planet_id);
                return output.ToList();
            }
        }
        public Planet GetIndividualPlanet(Planet planet)
        {
            Planet individualPlanet = new Planet();
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                individualPlanet.planet_ID = cnn.Execute("select ID from Planets where ID = @planet_ID", planet);
                individualPlanet.planet_Name = cnn.Execute("select Name from Planets where ID = @planet_ID", planet).ToString();
                return individualPlanet;
            }
        }
        public Satellite GetIndividualSatellite(Satellite satellite)
        {
            Satellite individualSatellite = new Satellite();
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                individualSatellite.satellite_Name = cnn.Execute("select Name from Satellites where ID = @satellite_ID", satellite).ToString();
                individualSatellite.satellite_ID = cnn.Execute("select ID from Satellites where ID = @satellite_ID", satellite);
                individualSatellite.planet_ID = cnn.Execute("select Planet_ID from Satellites where ID = @satellite_ID", satellite);
                return individualSatellite;
            }
        }
        public void SavePlanet(Planet planet)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Planets (Name) values (@planet_Name)", planet);
            }
        }
        public void SaveSatellite(Satellite satellite)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Planets (Name,Planet_ID) values (@satellite_Name,@planet_ID)", satellite);
            }
        }
        public void UpdatePlanet(Planet planet)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("update table Planets set Name = @planet_Name where ID = @planet_ID", planet);
            }
        }
        public void UpdateSatellite(Satellite satellite)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("update table Satellites set Name = @satellite_Name, Planet_ID = @planet_ID where ID = @satellite_ID", satellite);
            }
        }
        public void DeletePlanet(Planet planet)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("delete from Planets where ID = @planet_ID", planet);
            }
        }
        public void DeleteSatelite(Satellite satellite)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("delete from Satellites where ID = @satellite_ID", satellite);
            }
        }
    }
}

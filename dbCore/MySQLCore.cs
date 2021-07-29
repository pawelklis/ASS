using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;

/// <summary>

/// '''   ConnectionTest

/// '''   ExecuteNonQuery

/// '''   ExecuteScalar

/// '''   FillDatatable

/// '''   GetTablesList

/// '''   GetColumnsList

/// '''   Insert

/// '''   InsertList

/// '''   InsertOrUpdate

/// '''   Update

/// '''   UpdateList

/// '''   GetCount

/// '''   GetObject

/// '''   GetObject(list)

/// '''   Delete

/// '''   Truncate

/// '''   DropTable

/// '''   CreateTable

/// '''   AddColumn

/// '''   DeleteColumn

/// ''' </summary>
public class mySQLcore
{
    public static mySQLcore DB_Main()
    {
        return new mySQLcore("localhost", "ass_db", "mayday1");
    }




    public static void KillSleepConnections(mySQLcore m, int timeout)
    {
        try
        {
            DataTable dt = m.FillDatatable("show processlist;");
            int a = 0;
            int i = 0;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                if (dt.Rows[i]["Command"].ToString().ToLower() == "sleep")
                {
                    int ti = (int)dt.Rows[i]["time"];
                    if (ti > timeout)
                    {
                        m.ExecuteNonQuery("kill " + dt.Rows[i]["id"]);
                        a += 1;
                    }
                }
            }
            Console.WriteLine("killed sleeping connections: & a ");
        }
        catch (Exception ex)
        {
        }
    }



    public string ConnectionStr { get; }
    public Dictionary<DateTime, string> ErrorHistory { get; set; }
    public Dictionary<DateTime, string> EventHistory { get; set; }
    public string LastError { get; set; }

    public readonly Parameters ConParameters;
    public class Parameters
    {
        public string Database { get; set; }
        public string Password { get; set; }
        public string Server { get; set; }
        public string SecondServer { get; set; }
        public string User { get; set; }
        public int Port { get; set; }
        public string CharacterSet { get; set; }
        public int ConnectionTimeout { get; set; }
        public bool ConvertZeroDate { get; set; }
        public bool UseCompression { get; set; }
    }
    public string ConString()
    {
        return this.ConnectionStr;
    }


    public MySqlConnection con { get; set; }
    public MySqlCommand com { get; set; }
    public MySqlDataAdapter adpt { get; set; }




    public mySQLcore(string server, string database, string password, string SecondServer = null, bool UseCompression = true, string CharacterSet = "utf8", string user = "root", int port = 3306, int ConnectionTimeout = 28800, bool ConvertZeroDate = true)
    {
        this.ConParameters = new Parameters();
        {
            var withBlock = this.ConParameters;
            withBlock.Database = database;
            withBlock.Password = password;
            withBlock.Server = server;
            withBlock.User = user;
            withBlock.Port = port;
            withBlock.CharacterSet = CharacterSet;
            withBlock.ConnectionTimeout = ConnectionTimeout;
            withBlock.ConvertZeroDate = ConvertZeroDate;
            withBlock.UseCompression = UseCompression;
            withBlock.SecondServer = SecondServer;
        }



        string ConnectionString = "SERVER=" + server + ";UID=" + user + ";DATABASE=" + database + ";PORT=" + port + ";password=" + password + ";  Character Set=" + CharacterSet + "; Connect Timeout=" + ConnectionTimeout + ";Pooling=false;Convert Zero Datetime=" + ConvertZeroDate + ";";

        this.ConnectionStr = ConnectionString;
        if (SecondServer != null)
        {
            if (this.ConnectionTest() == false)
            {
                ConnectionString = "SERVER=" + SecondServer + ";UID=" + user + ";DATABASE=" + database + ";PORT=" + port + ";password=" + password + ";  Character Set=" + CharacterSet + "; Connect Timeout=" + ConnectionTimeout + ";Pooling=false;Convert Zero Datetime=" + ConvertZeroDate + ";";
                this.ConnectionStr = ConnectionString;
            }
        }
    }
    /// <summary>
    ///     ''' Test połączenia z bazą danych
    ///     ''' </summary>
    ///     ''' <returns></returns>
    public bool ConnectionTest()
    {
        MySqlConnection testcon = new MySqlConnection(this.ConnectionStr);
        try
        {
            testcon.Open();
            return true;
        }
        catch (Exception ex)
        {
            // ErrorHistoryAdd(ex)
            return false;
        }
        finally
        {
            testcon.Close();
        }

    }
    public MySqlConnection Connection()
    {
        if (con != null)
        {
            try
            {
                con.Close();
            }
            catch (Exception ex)
            {
            }
        }

        con = new MySqlConnection(ConnectionStr);


        con.Open();
        return con;
    }
    public Dictionary<string, object> toDict(object ob)
    {
        Dictionary<string, object> dict = new Dictionary<string, object>();
        PropertyInfo[] info = ob.GetType().GetProperties();
        foreach (var p in info)
            dict.Add(p.Name, p.GetValue(ob, null));
        return dict;
    }

    public T GetSingleObject<T>(string SQLcommand) where T : new()
    {
        List<T> l = new List<T>();

        var Props = typeof(T).GetProperties();
        DataTable dt = new DataTable();

        string command = "";
        command = SQLcommand;
        try
        {
            com = new MySqlCommand(command, Connection());
            adpt = new MySqlDataAdapter(command, con);
            adpt.Fill(dt);

            for (var i = 0; i <= dt.Rows.Count - 1; i++)
            {
                T ob = new T();

                for (var xx = 0; xx <= dt.Columns.Count - 1; xx++)
                {
                    foreach (var p in Props)
                    {
                        if (p.Name.ToLower() == dt.Columns[xx].ColumnName.ToLower())
                        {
                            var c = dt.Rows[i][xx];

                            try
                            {
                                if (p.PropertyType.Name == "Boolean")
                                {
                                    if (c.ToString().ToLower() == "true")
                                    {
                                        p.SetValue(ob, true, null);
                                        break;
                                    }
                                    else
                                    {
                                        p.SetValue(ob, false, null);
                                        break;
                                    }
                                }

                                if (p.PropertyType.Name == "Double")
                                {
                                    p.SetValue(ob, double.Parse(c.ToString().Replace(".", ",")), null/* TODO Change to default(_) if this is not a reference type */);
                                    break;
                                }

                                if (p.PropertyType.Name.StartsWith("Int"))
                                {
                                    p.SetValue(ob, int.Parse(c.ToString()), null/* TODO Change to default(_) if this is not a reference type */);
                                    break;
                                }

                                if (p.PropertyType.Name == "DateTime")
                                {
                                    p.SetValue(ob, DateTime.Parse(c.ToString()), null/* TODO Change to default(_) if this is not a reference type */);
                                    break;
                                }

                                if (p.PropertyType.Name == "String")
                                {
                                    p.SetValue(ob, c.ToString(), null/* TODO Change to default(_) if this is not a reference type */);
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                            }



                            try
                            {
                                if (dt.Columns[xx].DataType == c.GetType())
                                {
                                    p.SetValue(ob, dt.Rows[i][xx], null/* TODO Change to default(_) if this is not a reference type */);
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                }
                l.Add(ob);
            }
        }
        catch (Exception ex)
        {

            return default(T);
        }

        finally
        {
            try
            {
                Connection().Close();
            }
            catch (Exception ex)
            {
            }

            con.Close();
            con.Dispose();
            con = null/* TODO Change to default(_) if this is not a reference type */;
        }


        if (l == null)
            return default(T);
        if (l.Count == 0)
            return default(T);


        return l[0];
    }

    public bool ExecuteNonQuery(string sqlCommand)
    {
        try
        {
            com = new MySqlCommand(sqlCommand, Connection());
            com.ExecuteNonQuery();
        }
        catch (Exception ex)
        {

            return false;
        }


        return true;
    }
    public string ExecuteScalar(string sqlCommand)
    {
        string ret = "";

        com = new MySqlCommand(sqlCommand, Connection());
        try
        {
            ret = com.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {

            return "false";
        }
        finally
        {
            Connection().Close();
        }

        return ret;
    }
    public DataTable FillDatatable(string sqlCommand)
    {
        DataTable dt = new DataTable();

        try
        {
            com = new MySqlCommand(sqlCommand, Connection());
            adpt = new MySqlDataAdapter(sqlCommand, con);
            adpt.Fill(dt);
        }
        catch (Exception ex)
        {

            return null/* TODO Change to default(_) if this is not a reference type */;
        }
        finally
        {
            Connection().Close();
        }

        return dt;
    }



    public string GetInsertString(string TableName, string IdColumn, Dictionary<string, object> PropertiesDict)
    {
        string command = "";
        string strNazwypol = "";
        string strParametry = "";
        TableName = "`" + TableName + "`";
        foreach (var p in PropertiesDict)
        {
            // If p.Key <> IdColumn Then
            strNazwypol = strNazwypol + "`" + p.Key.ToLower() + "`,";
            strParametry = strParametry + "@" + p.Key.ToLower() + ",";
        }
        strNazwypol = strNazwypol.Substring(0, strNazwypol.Length - 1);
        strParametry = strParametry.Substring(0, strParametry.Length - 1);
        command = "INSERT INTO " + TableName + " (" + strNazwypol + ") VALUES (" + strParametry + ");select LAST_INSERT_ID();";
        return command;
    }
    public string GetInsertStringWithoutID(string TableName, string IdColumn, Dictionary<string, object> PropertiesDict)
    {
        string command = "";
        string strNazwypol = "";
        string strParametry = "";
        foreach (var p in PropertiesDict)
        {
            if (p.Key != IdColumn)
            {
                strNazwypol = strNazwypol + p.Key + ",";
                strParametry = strParametry + "@" + p.Key + ",";
            }
        }
        strNazwypol = strNazwypol.Substring(0, strNazwypol.Length - 1);
        strParametry = strParametry.Substring(0, strParametry.Length - 1);
        command = "INSERT INTO " + TableName + " (" + strNazwypol + ") VALUES (" + strParametry + ");select LAST_INSERT_ID();";
        return command;
    }
    public bool Insert(string TableName, string IdColumn, object ob)
    {
        Dictionary<string, object> PropertiesDict = new Dictionary<string, object>();
        PropertiesDict = toDict(ob);
        string command = GetInsertString(TableName, IdColumn, PropertiesDict);

        try
        {
            com = new MySqlCommand(command, Connection());
            com.CommandType = CommandType.Text;
            foreach (var p in PropertiesDict)
                com.Parameters.AddWithValue("@" + p.Key.ToLower(), p.Value);


            PropertyInfo[] info = ob.GetType().GetProperties();
            foreach (var p in info)
            {
                if (p.Name.ToLower() == IdColumn.ToLower())
                {
                    var aid = com.ExecuteScalar();
                    int id = int.Parse(aid.ToString());
                    p.SetValue(ob, id, null);
                }
            }
        }
        catch (Exception ex)
        {

            return false;
        }

        finally
        {
            con.Close();
            con.Dispose();
            con = null/* TODO Change to default(_) if this is not a reference type */;
        }

        return true;
    }
    /// <summary>
    ///     ''' Insert Listy Obiektów za pomocą transakcji
    ///     ''' </summary>
    ///     ''' <param name="TableName"></param>
    ///     ''' <param name="ListOb"></param>
    ///     ''' <returns></returns>
    public bool InsertList(string TableName, string idColumn, List<object> ListOb, bool BezID = true)
    {
        if (ListOb.Count == 0)
        {
            LastError = "MySQLCORE: InsertList: Lista nie posiada obiektów";
            return false;
        }

        Dictionary<string, object> PropertiesDict = new Dictionary<string, object>();
        PropertiesDict = toDict(ListOb[0]);
        string command = GetInsertString(TableName, idColumn, PropertiesDict);
        if (BezID == false)
            command = GetInsertStringWithoutID(TableName, idColumn, PropertiesDict);
        MySqlTransaction tr = null;
        try
        {
            com = new MySqlCommand(command, Connection());
            tr = con.BeginTransaction();
            com.Transaction = tr;

            foreach (var ob in ListOb)
            {
                PropertiesDict = new Dictionary<string, object>();
                PropertiesDict = toDict(ob);

                com.CommandType = CommandType.Text;
                com.Parameters.Clear();

                foreach (var p in PropertiesDict)
                    com.Parameters.AddWithValue("@" + p.Key, p.Value);

                PropertyInfo[] info = ob.GetType().GetProperties();
                bool sended = false;
                foreach (var p in info)
                {
                    if (p.Name == idColumn)
                    {
                        try
                        {
                            p.SetValue(ob, com.ExecuteNonQuery(), null/* TODO Change to default(_) if this is not a reference type */);
                            sended = true;
                        }
                        catch (Exception ex)
                        {
                        }
                        break;
                    }
                }
                try
                {
                    if (sended == false)
                        com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }
            }

            tr.Commit();
        }

        catch (Exception ex)
        {
            tr.Rollback();

            return false;
        }

        finally
        {
            con.Close();
            con.Dispose();
            con = null/* TODO Change to default(_) if this is not a reference type */;
        }

        return true;
    }

    public String InsertOnDuplicateUpdate(string id, string value)
    {
        mySQLcore m = mySQLcore.DB_Main();
        m.ExecuteNonQuery("INSERT INTO status VALUES (id='" + id + "', val='" + value + "') ON DUPLICATE KEY UPDATE val='" + value + "';");

            return "";
    }

    public string GetUpdatetString(string TableName, string idColumnName, Dictionary<string, object> PropertiesDict)
    {
        string command = "";
        string strNazwypol = "";
        string strParametry = "";
        string strPOLE = "";
        TableName = "`" + TableName + "`";
        foreach (var p in PropertiesDict)
        {
            if (p.Key != idColumnName)
                strPOLE = strPOLE + "`" + p.Key + "`=" + "@" + p.Key + ",";
        }

        strPOLE = strPOLE.Substring(0, strPOLE.Length - 1);

        command = "UPDATE " + TableName + " SET " + strPOLE + " WHERE " + idColumnName + "=@" + idColumnName + " ;";

        return command;
    }
    public bool InsertOrUpdate(string TableName, string idColumnName, object ob)
    {
        Dictionary<string, object> PropertiesDict = new Dictionary<string, object>();
        PropertiesDict = toDict(ob);
        dynamic wId = null;
        foreach (var p in PropertiesDict)
        {
            if (p.Key == idColumnName)
            {
                wId = p.Value;
                break;
            }
        }
        int cont = GetCount("select count(*) from " + TableName + " WHERE " + idColumnName + "='" + (string)wId + "';");

        if (cont == 0)
            return Insert(TableName, idColumnName, ob);
        else
            return Update(TableName, idColumnName, ob);

    }
    public bool Update(string TableName, string idColumnName, object ob)
    {
        Dictionary<string, object> PropertiesDict = new Dictionary<string, object>();
        PropertiesDict = toDict(ob);
        string command = GetUpdatetString(TableName, idColumnName, PropertiesDict);

        try
        {
            com = new MySqlCommand(command, Connection());
            com.CommandType = CommandType.Text;
            foreach (var p in PropertiesDict)
                com.Parameters.AddWithValue("@" + p.Key, p.Value);
            com.ExecuteNonQuery();
        }
        catch (Exception ex)
        {

            return false;
        }

        finally
        {
            con.Close();
            con.Dispose();
            con = null/* TODO Change to default(_) if this is not a reference type */;
        }

        return true;
    }
    /// <summary>
    ///     ''' Update Listy Obiektów za pomocą transakcji
    ///     ''' </summary>
    ///     ''' <param name="TableName"></param>
    ///     ''' <param name="ListOb"></param>
    ///     ''' <returns></returns>
    public bool UpdateList(string TableName, string idColumnName, List<object> ListOb)
    {
        if (ListOb.Count == 0)
        {
            LastError = "Lista nie posiada obiektów";
            return false;
        }

        Dictionary<string, object> PropertiesDict = new Dictionary<string, object>();
        PropertiesDict = toDict(ListOb[0]);
        string command = GetUpdatetString(TableName, idColumnName, PropertiesDict);

        MySqlTransaction tr = null;
        try
        {
            com = new MySqlCommand(command, Connection());
            tr = con.BeginTransaction();
            com.Transaction = tr;

            foreach (var ob in ListOb)
            {
                PropertiesDict = new Dictionary<string, object>();
                PropertiesDict = toDict(ob);

                com.CommandType = CommandType.Text;
                com.Parameters.Clear();

                foreach (var p in PropertiesDict)
                    com.Parameters.AddWithValue("@" + p.Key, p.Value);
                com.ExecuteNonQuery();
            }

            tr.Commit();
        }

        catch (Exception ex)
        {
            tr.Rollback();

            return false;
        }

        finally
        {
            con.Close();
            con.Dispose();
            con = null/* TODO Change to default(_) if this is not a reference type */;
        }

        return true;
    }
    /// <summary>
    ///     ''' Zwraca String
    ///     ''' </summary>
    ///     ''' <param name="sqlCommand"></param>
    ///     ''' <returns></returns>
    public string GetString(string sqlCommand, string ReturnValueIffNull = "")
    {
        string GS = ReturnValueIffNull;
        try
        {
            com = new MySqlCommand(sqlCommand, Connection());
            MySqlDataReader rd = com.ExecuteReader();
            while (rd.Read())
                GS = rd[0].ToString();
        }

        catch (Exception ex)
        {

            GS = ReturnValueIffNull;
        }

        finally
        {
            try
            {
                Connection().Close();
            }
            catch (Exception exx)
            {
            }
        }


        GS = ReturnValueIffNull;
        return GS;


    }
    /// <summary>
    ///     ''' Zwraca Byte
    ///     ''' </summary>
    ///     ''' <param name="sqlCommand"></param>
    ///     ''' <returns></returns>
    public byte[] GetByte(string sqlCommand)
    {
        byte[] GB = null;
        try
        {
            com = new MySqlCommand(sqlCommand, Connection());
            MySqlDataReader rd = com.ExecuteReader();
            while (rd.Read())
                GB = (byte[])rd[0];
        }

        catch (Exception ex)
        {

            GB = null;
        }

        finally
        {
            Connection().Close();
        }
        return GB;
    }
    /// <summary>
    ///     ''' Zwraca liczbę rekordów Integer
    ///     ''' </summary>
    ///     ''' <param name="sqlCommand"></param>
    ///     ''' <returns></returns>
    public int GetCount(string sqlCommand)
    {
        int GC = 0;
        try
        {
            com = new MySqlCommand(sqlCommand, Connection());
            GC = (int)com.ExecuteScalar();
        }
        catch (Exception ex)
        {
            GC = 0;
        }
        finally
        {
            if (GC < 0)
                GC = 0;
            Connection().Close();
        }
        return GC;
    }
    /// <summary>
    ///     ''' Tworzy dowolny obiekt na podstawie dowolnej klasy z pojedynczego rekordu z tabeli
    ///     ''' </summary>
    ///     ''' <typeparam name="T"></typeparam>
    ///     ''' <param name="TableName"></param>
    ///     ''' <param name="idColumnName"></param>
    ///     ''' <param name="id"></param>
    ///     ''' <returns></returns>
    public object GetObject<T>(string TableName, string idColumnName, string id) where T : new()
    {
        T ob = new T();
        var Props = typeof(T).GetProperties();
        DataTable dt = new DataTable();

        string command = "";
        command = "SELECT * FROM " + TableName + " WHERE " + idColumnName + "='" + id + "';";
        try
        {
            com = new MySqlCommand(command, Connection());
            adpt = new MySqlDataAdapter(command, con);
            adpt.Fill(dt);

            for (var i = 0; i <= dt.Rows.Count - 1; i++)
            {
                for (var xx = 0; xx <= dt.Columns.Count - 1; xx++)
                {
                    foreach (var p in Props)
                    {
                        if (p.Name == dt.Columns[xx].ColumnName)
                        {
                            var c = dt.Rows[i][xx];
                            try
                            {
                                if (dt.Columns[xx].DataType == c.GetType())
                                    p.SetValue(ob, dt.Rows[i][xx], null/* TODO Change to default(_) if this is not a reference type */);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {

            return null;
        }

        finally
        {
            Connection().Close();
            con.Close();
            con.Dispose();
            con = null/* TODO Change to default(_) if this is not a reference type */;
        }


        return ob;
    }
    /// <summary>
    ///     ''' Tworzy listę obiektów na podstawie dowolnej klasy wg komendy mysQL
    ///     ''' </summary>
    ///     ''' <typeparam name="T"></typeparam>
    ///     ''' <param name="SQLcommand"></param>
    ///     ''' <returns></returns>
    public List<T> GetObject<T>(string SQLcommand) where T : new()
    {
        List<T> l = new List<T>();

        var Props = typeof(T).GetProperties();
        DataTable dt = new DataTable();

        string command = "";
        command = SQLcommand;
        try
        {
            com = new MySqlCommand(command, Connection());
            adpt = new MySqlDataAdapter(command, con);
            adpt.Fill(dt);

            for (var i = 0; i <= dt.Rows.Count - 1; i++)
            {
                T ob = new T();
                for (var xx = 0; xx <= dt.Columns.Count - 1; xx++)
                {
                    foreach (var p in Props)
                    {
                        if (p.Name.ToLower() == dt.Columns[xx].ColumnName.ToLower())
                        {
                            var c = dt.Rows[i][xx];
                            try
                            {
                                if (p.PropertyType.Name == "Boolean")
                                {
                                    if (c.ToString().ToLower() == "true")
                                    {
                                        p.SetValue(ob, true, null);
                                        break;
                                    }
                                    else
                                    {
                                        p.SetValue(ob, false, null);
                                        break;
                                    }
                                }

                                if (p.PropertyType.Name == "Double")
                                {
                                    p.SetValue(ob, double.Parse(c.ToString().Replace(".", ",")), null/* TODO Change to default(_) if this is not a reference type */);
                                    break;
                                }

                                if (p.PropertyType.Name.StartsWith("Int"))
                                {
                                    p.SetValue(ob, int.Parse(c.ToString()), null/* TODO Change to default(_) if this is not a reference type */);
                                    break;
                                }

                                if (p.PropertyType.Name == "DateTime")
                                {
                                    p.SetValue(ob, DateTime.Parse(c.ToString()), null/* TODO Change to default(_) if this is not a reference type */);
                                    break;
                                }

                                if (p.PropertyType.Name == "String")
                                {
                                    p.SetValue(ob, c.ToString(), null/* TODO Change to default(_) if this is not a reference type */);
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                            }



                            try
                            {
                                if (dt.Columns[xx].DataType == c.GetType())
                                {
                                    p.SetValue(ob, dt.Rows[i][xx], null/* TODO Change to default(_) if this is not a reference type */);
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                }
                l.Add(ob);
            }
        }
        catch (Exception ex)
        {

            return null;
        }

        finally
        {
            Connection().Close();
            con.Close();
            con.Dispose();
            con = null/* TODO Change to default(_) if this is not a reference type */;
        }


        return l;
    }
    public bool Delete(string TableName, string idColumnName, string id)
    {
        return this.ExecuteNonQuery("DELETE from " + TableName + " WHERE " + idColumnName + "='" + id + "';");
    }

    public bool Truncate(string TableName)
    {
        return this.ExecuteNonQuery("TRUNCATE " + TableName + ";");
    }

    public bool DropTable(string TableName)
    {
        return this.ExecuteNonQuery("Drop TABLE " + TableName + ";");
    }







    public string InsertUpdateDuplicateKey(string tablename, string columnid, object ob)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("INSERT  INTO " + tablename + " ");



        sb.Append(getinsertduplicateString(ob));

        this.ExecuteNonQuery(sb.ToString());


        return sb.ToString();
    }


    private string getinsertduplicateString(object ob)
    {
        PropertyInfo[] props = ob.GetType().GetProperties();

        StringBuilder sb = new StringBuilder();
        sb.Append(" (");

        foreach (var p in props)
        {
            sb.Append(p.Name);
            sb.Append(",");
        }
        if (sb.ToString().EndsWith(","))
            sb.Remove(sb.Length - 1, 1);

        sb.Append(") ");

        sb.AppendLine(" VALUES ");

        sb.Append(" (");

        foreach (var p in props)
        {
            sb.Append("'");
            if (p.PropertyType.Name == "Double")
            {
                string vv = p.GetValue(ob, null).ToString().Replace(",", ".");
                sb.Append(vv);
            }
            else
                sb.Append(p.GetValue(ob, null));

            sb.Append("'");
            sb.Append(",");
        }

        if (sb.ToString().EndsWith(","))
            sb.Remove(sb.Length - 1, 1);

        sb.Append(") ");
        sb.AppendLine("  ON DUPLICATE KEY UPDATE ");

        foreach (var p in props)
        {
            sb.Append("`");
            sb.Append(p.Name);
            sb.Append("` = ");
            sb.Append("'");
            if (p.PropertyType.Name == "Double")
            {
                string vv = p.GetValue(ob, null).ToString().Replace(",", ".");
                sb.Append(vv);
            }
            else
                sb.Append(p.GetValue(ob, null));
            sb.Append("',");
        }
        if (sb.ToString().EndsWith(","))
            sb.Remove(sb.Length - 1, 1);

        sb.Append(";");
        return sb.ToString();
    }
}

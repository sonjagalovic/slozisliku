using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SloziSliku_29_2019
{
    public class PuzzleDB
    {
        SqlConnection _connection = DBConnection.Connection;

        internal void upisiRezultat(string imeIgraca, int brRedova, int brKolona, int vremeUSekundama, int ukupnoPoteza)
        {
            _connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _connection;
            cmd.CommandText = @"insert into rezultati(imeIgraca, brRedova, brKolona, vremeUSekundama, ukupnoPoteza) 
                                values(@imeIgraca, @brRedova, @brKolona, @vremeUSekundama, @ukupnoPoteza)";
            cmd.Parameters.AddWithValue("@imeIgraca", imeIgraca);
            cmd.Parameters.AddWithValue("@brRedova", brRedova);
            cmd.Parameters.AddWithValue("@brKolona", brKolona);
            cmd.Parameters.AddWithValue("@ukupnoPoteza", ukupnoPoteza);
            cmd.Parameters.AddWithValue("@vremeUSekundama", vremeUSekundama);

            int rezultat = cmd.ExecuteNonQuery();

            _connection.Close();
        }

        internal List<Rezultat> dajTop10()
        {
            List<Rezultat> rezultati = new List<Rezultat>();

            _connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _connection;
            cmd.CommandText = @"select top 10 *
                                from rezultati 
                                order by vremeUSekundama asc, ukupnoPoteza asc";

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                rezultati.Add(new Rezultat(
                        int.Parse(reader["id"].ToString()),
                        reader["imeIgraca"].ToString(),
                        int.Parse(reader["brRedova"].ToString()),
                        int.Parse(reader["brKolona"].ToString()),
                        int.Parse(reader["ukupnoPoteza"].ToString()),
                        int.Parse(reader["vremeUSekundama"].ToString())
                    ));
            }
            reader.Close();

            _connection.Close();

            return rezultati;
        }
    }
}

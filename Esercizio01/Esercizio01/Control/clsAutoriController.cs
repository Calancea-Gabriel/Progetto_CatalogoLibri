using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

using Esercizio01.Model;

namespace Esercizio01.Control
{
    internal class clsAutoriController
    {
        private adoNetSQL sqlAutore;
        private bool pErrore;
        private string pStrSQL;
        private List<clsAutori> listaAutori;

        public clsAutori Autore;
        public string msgErrore;

        public clsAutoriController()
        {
            string pathDB = Application.StartupPath + "\\CatalogoLibri.mdf";
            sqlAutore = new adoNetSQL(pathDB);
            Autore = new clsAutori();
            Autore.ValAutore = ' ';
            msgErrore = string.Empty;
        }

        public bool aggiungi()
        {
            pErrore = false;

            sqlAutore.cmd.Parameters.AddWithValue("@CognAutore", Autore.CognAutore);
            sqlAutore.cmd.Parameters.AddWithValue("@NomeAutore", Autore.NomeAutore);
            sqlAutore.cmd.Parameters.AddWithValue("@DatNasAutore", Autore.DatNasAutore);
            sqlAutore.cmd.Parameters.AddWithValue("@FotoAutore", Autore.FotoAutore);
            sqlAutore.cmd.Parameters.AddWithValue("@ValAutore", Autore.ValAutore);


            pStrSQL = "INSERT INTO Autori (CognAutore, NomeAutore, DatNasAutore, FotoAutore, ValAutore) VALUES (@CognAutore, @NomeAutore, @DatNasAutore, @FotoAutore, @ValAutore)";

            try
            {
                int Risultato = sqlAutore.eseguiNonQuery(pStrSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                msgErrore = "ATTENZIONE !! " + ex.Message;
                pErrore = true;
            }
            finally
            {
                if (!pErrore)
                    msgErrore = "Autore inserito correttamente !!!";
            }

            return pErrore;
        }

        public bool modifica()
        {
            pErrore = false;

            sqlAutore.cmd.Parameters.AddWithValue("@IdAutore", Autore.IdAutore);
            sqlAutore.cmd.Parameters.AddWithValue("@CognAutore", Autore.CognAutore);
            sqlAutore.cmd.Parameters.AddWithValue("@NomeAutore", Autore.NomeAutore);
            sqlAutore.cmd.Parameters.AddWithValue("@DatNasAutore", Autore.DatNasAutore);
            sqlAutore.cmd.Parameters.AddWithValue("@FotoAutore", Autore.FotoAutore);
            sqlAutore.cmd.Parameters.AddWithValue("@ValAutore", Autore.ValAutore);

            pStrSQL = "UPDATE Autori SET CognAutore = @CognAutore, NomeAutore = @NomeAutore, DatNasAutore = @DatNasAutore, FotoAutore = @FotoAutore, ValAutore = @ValAutore WHERE IdAutore = @IdAutore";

            try
            {
                int Risultato = sqlAutore.eseguiNonQuery(pStrSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                msgErrore = "ATTENZIONE !! " + ex.Message;
                pErrore = true;
            }
            finally
            {
                if (!pErrore)
                    msgErrore = "Autore modificato correttamente !!!";
            }

            return pErrore;
        }

        public List<clsAutori> elencoAutori()
        {
            listaAutori = new List<clsAutori>();

            pStrSQL = "SELECT * FROM Autori WHERE ValAutore = ''";

            caricaListaAutori();

            return listaAutori;
        }

        public List<clsAutori> elencoAutoriAnnullati()
        {
            listaAutori = new List<clsAutori>();

            pStrSQL = "SELECT * FROM Autori WHERE ValAutore = 'A'";

            caricaListaAutori();

            return listaAutori;
        }

        private void caricaListaAutori()
        {
            SqlDataReader dataReader;

            pErrore = false;

            try
            {
                dataReader = sqlAutore.creaLettore(pStrSQL, CommandType.Text);
                while (dataReader.Read())
                {
                    clsAutori detAutore = new clsAutori();
                    detAutore.IdAutore = Convert.ToInt32(dataReader["IdAutore"]);
                    detAutore.CognAutore = dataReader["CognAutore"].ToString();
                    detAutore.NomeAutore = dataReader["NomeAutore"].ToString();
                    detAutore.DatNasAutore = Convert.ToDateTime(dataReader["DatNasAutore"]);
                    detAutore.FotoAutore = dataReader["FotoAutore"].ToString();
                    detAutore.ValAutore = Convert.ToChar(dataReader["ValAutore"]);
                    listaAutori.Add(detAutore);
                }
            }
            catch (Exception ex)
            {
                msgErrore = "ATTENZIONE !! " + ex.Message;
                pErrore = true;
            }
            finally
            {
                if (!pErrore)
                {
                    msgErrore = "Lista creata con Successo !!";
                    sqlAutore.chiudiLettore();
                }
            }
        }

        public clsAutori datiAutore()
        {
            pErrore = false;
            clsAutori modAutore = new clsAutori();
            DataTable tabellaAutori = null;

            sqlAutore.cmd.Parameters.AddWithValue("@IdAutore", Autore.IdAutore);

            pStrSQL = "SELECT * FROM Autori WHERE IdAutore = @IdAutore";

            try
            {
                tabellaAutori = sqlAutore.eseguiQuery(pStrSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                msgErrore = ex.Message;
                pErrore = true;
            }
            finally
            {
                if (!pErrore)
                {
                    modAutore.IdAutore = Autore.IdAutore;
                    modAutore.CognAutore = tabellaAutori.Rows[0].ItemArray[1].ToString();
                    modAutore.NomeAutore = tabellaAutori.Rows[0].ItemArray[2].ToString();
                    modAutore.DatNasAutore = Convert.ToDateTime(tabellaAutori.Rows[0].ItemArray[3].ToString());
                    modAutore.FotoAutore = tabellaAutori.Rows[0].ItemArray[4].ToString();
                    modAutore.ValAutore = Convert.ToChar(tabellaAutori.Rows[0].ItemArray[5]);
                }
            }

            return modAutore;
        }

    }
}

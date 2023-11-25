using Esercizio01.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Esercizio01.Control
{
    internal class clsEditoriController
    {
        private adoNetSQL sqlEditore;
        private bool pErrore;
        private string pStrSQL;
        private List<clsEditori> listaEditori;

        public clsEditori Editore;
        public string msgErrore;

        public clsEditoriController()
        {
            string pathDB = Application.StartupPath + "\\CatalogoLibri.mdf";
            sqlEditore = new adoNetSQL(pathDB);
            Editore = new clsEditori();
            Editore.ValEditore = ' ';
            msgErrore = string.Empty;
        }

        public bool aggiungi()
        {
            pErrore = false;

            sqlEditore.cmd.Parameters.AddWithValue("@NomeEditore", Editore.NomeEditore);
            sqlEditore.cmd.Parameters.AddWithValue("@ValEditore", Editore.ValEditore);


            pStrSQL = "INSERT INTO Editori (NomeEditore, ValEditore) VALUES (@NomeEditore, @ValEditore)";

            try
            {
                int Risultato = sqlEditore.eseguiNonQuery(pStrSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                msgErrore = "ATTENZIONE !! " + ex.Message;
                pErrore = true;
            }
            finally
            {
                if (!pErrore)
                    msgErrore = "Editore inserito correttamente !!!";
            }

            return pErrore;
        }

        public bool modifica()
        {
            pErrore = false;

            sqlEditore.cmd.Parameters.AddWithValue("@NomeEditore", Editore.NomeEditore);
            sqlEditore.cmd.Parameters.AddWithValue("@ValEditore", Editore.ValEditore);

            pStrSQL = "UPDATE Editori SET NomeEditore = @NomeEditore, ValEditore = @ValEditore WHERE NomeEditore = @NomeEditore";

            try
            {
                int Risultato = sqlEditore.eseguiNonQuery(pStrSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                msgErrore = "ATTENZIONE !! " + ex.Message;
                pErrore = true;
            }
            finally
            {
                if (!pErrore)
                    msgErrore = "Editore modificato correttamente !!!";
            }

            return pErrore;
        }

        public bool chkEditore()
        {
            bool controllo = true;
            string Risultato = string.Empty;

            sqlEditore.cmd.Parameters.AddWithValue("@NomeEditore", Editore.NomeEditore);

            pStrSQL = "SELECT COUNT(*) FROM Editori WHERE NomeEditore = @NomeEditore";

            try
            {
                Risultato = sqlEditore.eseguiScalar(pStrSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                msgErrore = "ATTENZIONE !! " + ex.Message;
                controllo = false;
            }
            finally
            {
                if (controllo)
                    if (Convert.ToInt32(Risultato) != 0)
                    {
                        msgErrore = $"l'Editore [{Editore.NomeEditore}] è già presente !!!";
                        controllo = false;
                    }
            }

            return controllo;
        }

        public List<clsEditori> elencoEditori()
        {
            listaEditori = new List<clsEditori>();

            pStrSQL = "SELECT * FROM Editori WHERE ValEditore = '' ";

            caricaListaEditori();

            return listaEditori;
        }

        public List<clsEditori> elencoEditoriAnnullati()
        {
            listaEditori = new List<clsEditori>();

            pStrSQL = "SELECT * FROM Editori WHERE ValEditore = 'A' ";

            caricaListaEditori();

            return listaEditori;
        }

        private void caricaListaEditori()
        {
            SqlDataReader dataReader;

            pErrore = false;

            try
            {
                dataReader = sqlEditore.creaLettore(pStrSQL, CommandType.Text);
                while (dataReader.Read())
                {
                    clsEditori detEditore = new clsEditori();
                    detEditore.IdEditore = Convert.ToInt32(dataReader["IdEditore"]);
                    detEditore.NomeEditore = dataReader["NomeEditore"].ToString();
                    detEditore.ValEditore = Convert.ToChar(dataReader["ValEditore"]);
                    listaEditori.Add(detEditore);
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
                    sqlEditore.chiudiLettore();
                }
            }

        }

        public clsEditori datiEditore()
        {
            pErrore = false;
            clsEditori modEditore = new clsEditori();
            DataTable tabellaEditori = null;

            sqlEditore.cmd.Parameters.AddWithValue("@IdEditore", Editore.IdEditore);

            pStrSQL = "SELECT NomeEditore, ValEditore FROM Editori WHERE IdEditore = @IdEditore";

            try
            {
                tabellaEditori = sqlEditore.eseguiQuery(pStrSQL, CommandType.Text);
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
                    modEditore.NomeEditore = tabellaEditori.Rows[0].ItemArray[0].ToString();
                    modEditore.ValEditore = Convert.ToChar(tabellaEditori.Rows[0].ItemArray[1]);
                }
            }

            return modEditore;
        }

        public List<clsEditori> elencoEditoriLibri()
        {
            pErrore = false;
            listaEditori = new List<clsEditori>();
            SqlDataReader dataReader;

            pStrSQL = "SELECT IdEditore, NomeEditore FROM Editori WHERE ValEditore = '' ORDER BY IdEditore ASC";

            try
            {
                dataReader = sqlEditore.creaLettore(pStrSQL, CommandType.Text);
                while (dataReader.Read())
                {
                    clsEditori detEditore = new clsEditori();
                    detEditore.IdEditore = Convert.ToInt32(dataReader["IdEditore"]);
                    detEditore.NomeEditore = dataReader["NomeEditore"].ToString();
                    listaEditori.Add(detEditore);
                }
            }
            catch (Exception ex)
            {
                msgErrore = ex.Message;
                pErrore = true;
            }
            finally
            {
                msgErrore = "Lista creata con Successo !!!";
                sqlEditore.chiudiLettore();
            }

            return listaEditori;
        }
    }
}

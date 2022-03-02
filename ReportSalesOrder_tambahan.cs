using MySql.Data;
using MySql.Data.MySqlClient;
using System;
private void xrLabel1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
	string sodoc = GetCurrentColumnValue("DocNo").ToString();
	string num = GetCurrentColumnValue("Number").ToString();
	string datedel = "";
	string qtydel = "";
	string iString = "";

	string connStr = "server=192.168.88.88;user=root;database=sim_krisanthium;port=3306;password=19K23O15P";
		MySqlConnection connDb = new MySqlConnection(connStr);
			try
			{
				Console.WriteLine("Connecting to MySQL...");
				connDb.Open();
					string sqlDb = "SELECT s.Number, c.DeliveryDate, c.Qty FROM salesorderd s left join salesordersch c on s.DocNo=c.DocNo and s.Number=c.Number WHERE s.DocNo='"+sodoc+"' and s.Number = '"+num+"'";
					MySqlCommand cmdDb = new MySqlCommand(sqlDb, connDb);
					cmdDb.ExecuteNonQuery();
					using (MySqlDataReader reader = cmdDb.ExecuteReader())
					{
						while (reader.Read())
						{
							datedel	= Convert.ToDateTime(reader["DeliveryDate"]).ToString("dd MMM yyyy", new System.Globalization.CultureInfo("id-ID")); ;
							//qtydel	= reader["Qty"].ToString();
						}
						lblDateDel.Text 	= datedel;
						//lblQtyDel.Text 	= qtydel;					
					}
			}
			catch (Exception ex)
			{
			}
			connDb.Close();
}




using MySql.Data;
using MySql.Data.MySqlClient;
private void lbldp_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
	string custcode = GetCurrentColumnValue("CustomerCode").ToString();
	string totgross = GetCurrentColumnValue("TotalGross").ToString();
	string dp = "";
	string ppnn = "";
	string connStr = "server=192.168.88.88;user=root;database=sim_krisanthium;port=3306;password=19K23O15P";
		MySqlConnection connDb = new MySqlConnection(connStr);
			try
			{
				Console.WriteLine("Connecting to MySQL...");
				connDb.Open();
					string sqlDb = "SELECT s.*, sum(p.Usage)totdp FROM salesinvoiceh s left join salesinvoicedp p on s.DocNo=p.DocNo where customercode = '"+custcode+"'";
					MySqlCommand cmdDb = new MySqlCommand(sqlDb, connDb);
					cmdDb.ExecuteNonQuery();
					using (MySqlDataReader reader = cmdDb.ExecuteReader())
					{
						while (reader.Read())
						{
							dp	= reader["totdp"].ToString();
							decimal dpnya = decimal.Parse(dp);
            					decimal gross = decimal.Parse(totgross);
							decimal hasil = gross - dpnya;
							decimal Tax = hasil*(decimal)(0.1);
							ppnn	= Tax.ToString();
						}
						lbldp.Text 	= String.Format("{0:n}",Double.Parse(dp));
						lblPpn.Text	= String.Format("{0:n}",Double.Parse(ppnn));
					}
			}
			catch (Exception ex)
			{
			}
			connDb.Close();
}



<?
	$db_host= "220.69.209.170";
	$db_user= "cglab";
	$db_password="clws";
	$db_name="jjs";
	
	$conn = mysql_connect("$db_host", "$db_user", "$db_password");
	mysql_select_db("$db_name", $conn);

	$res=mysql_query("SELECT * FROM soccer order by time asc");

	while($data = mysql_fetch_assoc($res))
	{
		echo"$data[stage]/ ";
		echo"$data[ball]/";
		echo"$data[percent]/ ";
		echo"$data[average]/";
		echo"$data[max]/ ";
		echo"$data[min]/";
		echo"$data[time]/";
	}
	
?>
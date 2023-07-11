<?php
    $con = mysqli_connect("220.69.209.170", "cglab","clws","jjs");
    
    
    $stage = $_POST["stage"];
    $ball =  $_POST["ball"];
    $percent = $_POST["percent"];
    $average =  $_POST["average"];
    $max = $_POST["max"];
    $min =  $_POST["min"];

    $query  = "INSERT INTO soccer (stage, ball, percent, average, max, min) VALUES ('$stage','$ball' 
    ,'$percent' ,'$average' ,'$max' ,'$min')";
    $statement = mysqli_prepare($con, $query);
    
    mysqli_query($con, $query);

    $response = array();
    $response["success"] = true;
    $response["stage"] = $stage;
    $response["ball"] = $ball;
    $response["percent"] = $percent;
    $response["average"] = $average;
    $response["max"] = $max;
    $response["min"] = $min;

    echo json_encode($response);
?>

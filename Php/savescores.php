<?php
$servername = "127.0.0.1";
$username = "regenboogslang";
$password = "mythenw8woord";
$dbname = "mythen";

$deviceId = $_POST['deviceId'];
$name = $_POST['name'];
$score = $_POST['score'];
$pickups = $_POST['pickups'];
$distance = $_POST['distance'];
$time = $_POST['time'];
$deaths = $_POST['deaths'];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

if($conn->query("SELECT * FROM Scores WHERE deviceid = '$deviceId'")->num_rows > 0) {
    
    echo "Score Updated <br>";
    
    $sql2 = "UPDATE Scores SET pickups = '$pickups', distance = '$distance', time = '$time', deaths = '$deaths' WHERE deviceId = '$deviceId'";
        
} else {
    
    echo "TEST Make new Score: " . $result . "<br>" . $conn->error . "<br>";
    
    $sql2 = "INSERT INTO `$dbname`.`Scores` (name, score, pickups, distance, time, deaths, deviceId) VALUES ('$name', '$score', '$pickups', '$distance', '$time,', '$deaths', '$deviceId')";
}


if ($conn->query($sql2) === TRUE) {
    echo "New record created successfully";
} else {
    echo "Error: " . $sql2 . "<br>" . $conn->error;
}

$conn->close();
?>

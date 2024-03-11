<!DOCTYPE html>
<html>

<head>
    <title>Page Load Counter</title>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
</head>

<body>
    <div class="container">
        <h1>Page Load Counter</h1>
        <p>Loading count: <span id="loadCount"></span></p>
    </div>
    <!-- Include jQuery -->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <!-- Include Bootstrap JS -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script>
        $(document).ready(function () {
            $.getJSON('/Count/index', function (data) {
                $('#loadCount').text(data.count);
            });
        });
    </script>
</body>

</html>
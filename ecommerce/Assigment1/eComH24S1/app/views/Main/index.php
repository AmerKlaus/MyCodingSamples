<head>

    <title>Site Landing Page</title>



    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL"
        crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>

    <style>
        nav {
            position: fixed;
            left: 0;
            top: 0;
            width: 150px;
            height: 100%;
            padding: 10px;
            display: flex;
            /* Add flexbox display */
            flex-direction: column;
            /* Arrange items vertically */
            background-color: #f8f9fa;
            /* Move background color here */
        }

        nav ul {
            list-style-type: none;
            padding: 0;
            margin: 0;
        }

        nav ul li {
            margin-bottom: 10px;
        }

        nav ul li a {
            text-decoration: none;
            color: #000;
        }
    </style>
</head>

<body>
    <!-- Navigation menu -->
    <div class="wrapper">
        <nav>
            <ul>
                <li><a href="/Main/index">Landing Page</a></li>
                <li><a href="/Main/about_us">About Us</a></li>
                <li><a href="/Message/contact">Contact Us</a></li>
                <li><a href="/Message/read">See the messages we get</a></li>

            </ul>
        </nav>
        <div class="container">
            <h1> Welcome to the Site Landing Page</h1>
            <p>Welcome to our project where we will be developping a web application for the health insurance department
                of ACME Insurance Solutions, centered around improving the claim submission and review process.</p>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            // AJAX request to fetch the counter
            $.ajax({
                url: 'index.php?controller=Count&action=index',
                method: 'POST',
                success: function (response) {
                    // Display the counter at the bottom right corner of the page
                    $('#counter').text('Page Access Count: ' + response.count);
                },
                error: function () {
                    // Handle error if counter fetch fails
                    console.log('Failed to fetch counter');
                }
            });
        });
    </script>
</body>

</html>
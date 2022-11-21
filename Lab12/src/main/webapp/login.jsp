<%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" %>
<!DOCTYPE html>
<html>
<head>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-iYQeCzEYFbKjA/T2uDLTpkwGzCiq6soy8tYaI1GyVh/UjpbCx/TYkiZhlZB6+fzT" crossorigin="anonymous">
    <title>Lab12</title>
    <style>
        body {
            padding: 25px;
        }
    </style>
</head>
<body>
<main>
    <form method="post" action="j_security_check">
        <div class="mb-3">
            username <input class="form-control" type="text" name="j_username" />
        </div>
        <div class="mb-3">
            password <input class="form-control" type="password" name="j_password" />
        </div>
        <button class="btn btn-primary" type="submit">Submit</button>
    </form>
</main>
</body>
</html>
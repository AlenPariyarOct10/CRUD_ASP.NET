<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteUser.aspx.cs" Inherits="CRUD_App.DeleteUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />

    <title></title>
</head>
<body>
    <asp:Label ID="Output" runat="server"></asp:Label>

    <form runat="server">

        <asp:HiddenField ID="HiddenRollNumber" runat="server" />

        <!-- Delete Student Modal -->
        <div class="modal fade" id="deleteModal" tabindex="-1" aria-labelledby="deleteModal" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">

                    <div class="modal-header">
                        <h5 class="modal-title" id="deleteModallevel">Delete Student</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>

                    <div class="m-2">
                        Are you sure you want to delete this student?
                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">No</button>
                        <asp:Button ID="Button1" runat="server" Text="Yes" CssClass="btn btn-danger" OnClick="btn_delete_student" />
                    </div>

                </div>
            </div>
        </div>





        <div>
            <div class="alert alert-primary" role="alert">
                <h1 class="display-5">Student Management</h1>
                  <button type="button" class="btn btn-danger" runat="server" data-bs-toggle="modal" data-bs-target="#deleteModal">
      Delete Student
  </button>
            </div>
            <div class="m-4">
                <table class="table">
                    <thead class="thead-dark">
                        <tr>
                            <th scope="col">Roll</th>
                            <th scope="col">Name</th>
                            <th scope="col">Address</th>
                            <th scope="col">Semester</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Label ID="UserId" runat="server"></asp:Label>
                    </tbody>
                </table>
            </div>
        </div>
      
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>

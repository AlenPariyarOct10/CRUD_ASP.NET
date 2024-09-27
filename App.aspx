<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="App.aspx.cs" Inherits="CRUD_App.App" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <title>Student Management</title>
</head>
<body>

    <asp:Label ID="Output" runat="server"></asp:Label>

    <form runat="server">

        <!-- Add Student Modal -->
        <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Add New Student</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                       <div class="mb-3">
    <label for="rollNo" class="form-label">Roll No.</label>
    <asp:TextBox ID="rollNo" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
    
    <asp:RequiredFieldValidator 
        runat="server" 
        ForeColor="Red" 
        ErrorMessage="*Roll number cannot be empty." 
        ControlToValidate="rollNo" 
        Display="Dynamic"></asp:RequiredFieldValidator>
        
    <asp:RangeValidator 
        runat="server" 
        ID="rangeValidatorRoll" 
        ForeColor="Red" 
        ErrorMessage="*Invalid Roll number. Must be between 1 and 1000." 
        ControlToValidate="rollNo" 
        MinimumValue="1" 
        MaximumValue="1000" 
        Type="Integer" 
        Display="Dynamic"></asp:RangeValidator>
    

    
    <br />
</div>

                        <div class="mb-3">
                            <label for="inputName" class="form-label">Name</label>
                            <asp:TextBox ID="inputName" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ForeColor="Red" ErrorMessage="*Name field cannot be empty" ControlToValidate="inputName"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ForeColor="Red" ErrorMessage="Invalid name" ControlToValidate="inputName" ValidationExpression="^[a-z A-Z]+$"></asp:RegularExpressionValidator>
                        </div>
                        <div class="mb-3">
                            <label for="inputAddress" class="form-label">Address</label>
                            <asp:TextBox ID="inputAddress" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ForeColor="Red" ErrorMessage="*Address field cannot be empty" ControlToValidate="inputAddress"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ForeColor="Red" ErrorMessage="Invalid name" ControlToValidate="inputAddress" ValidationExpression="^[a-z A-Z 0-9]+$"></asp:RegularExpressionValidator>

                        </div>
                        <div class="mb-3">
                            <label for="inputSemester" class="form-label">Semester</label>
                            <asp:TextBox ID="inputSemester" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ErrorMessage="*Semester Field cannot be empty" ForeColor="Red" ControlToValidate="inputSemester"></asp:RequiredFieldValidator>
                            <br />
                            <asp:RangeValidator Type="Integer" MinimumValue="1" MaximumValue="8" runat="server" ForeColor="Red" ErrorMessage="*Semester value must be between 1 to 8" ControlToValidate="inputSemester"></asp:RangeValidator>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <asp:Button ID="btnSave" runat="server" Text="Save changes" CssClass="btn btn-primary" OnClick="btn_add_student" />
                    </div>
                </div>
            </div>
        </div>

    </form>



    <div>
        <div class="alert alert-primary" role="alert">
            <h1 class="display-5">Student Management</h1>
            <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
                Add Student
            </button>
        </div>
        <div class="m-4">
            <table class="table">
                <thead class="thead-dark">
                    <tr>
                        <th scope="col">ID</th>
                        <th scope="col">Roll</th>
                        <th scope="col">Name</th>
                        <th scope="col">Address</th>
                        <th scope="col">Semester</th>
                        <th scope="col">Operation</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Label ID="TableOut" runat="server"></asp:Label>
                </tbody>
            </table>
        </div>
    </div>


    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>

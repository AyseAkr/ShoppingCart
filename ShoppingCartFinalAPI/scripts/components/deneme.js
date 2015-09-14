/** @jsx React.DOM */

var Deneme = React.createClass({
    render: function() {

       
            return (
              
    <div class="modal fade" id="popUpWindow">
        <div class="modal-dialog">
            <div class="modal-content">

             
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h3 class="modal-title">Log In</h3>
                </div>

             
                <div class="modal-body">
                    <form role="form">
                        <div class="form-group">
                            <input type="email" class="form-control" placeholder="Email">
                        </div>
                        <div class="form-group">
                            <input type="password" class="form-control" placeholder="Password">
                        </div>
                    </form>
                </div>

              
                <div class="modal-footer">
                    <button class="btn btn-primary btn-block">Submit</button>
                </div>

            </div>
        </div>
    </div>

</div>
		
        );
    }
});
         
/** @jsx React.DOM */
var Popup = React.createClass({

  render: function() {

        return (
          <div class="modal fade" id="basicModal" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
          <div class="modal-dialog">
           <div class="modal-content">
            <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&amp;times;</button>
            <h4 class="modal-title" id="myModalLabel">Modal title</h4>
            </div>
            <div class="modal-body">
                <h3>Modal Body</h3>
            </div>
            <div class="modal-footer">
			
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                <button onClick={Product.addToCart}>Save changes</button>
           </div>
           </div>
         </div>
        </div>
        );
    }

});



var Product = React.createClass({
getInitialState: function() {
     return {editing: false};
 },
    addToCart: function(e) {

        $.publish('cart.added', this.props.data);

    },

removeToCart: function(e) {
    
 
        $.publish('cart.removed', this.props.data.id);
      

    },
	popupClick: function(e){
	
	this.setState({editing: true});
	
       return (  <Popup>Sssssss </Popup>)
	
	},
    render: function() {
     
        var data = this.props.data;
        var popupdata = Popup.openPopup;
        return (
          <div className="thumbnail">
          <img src={data.image} alt="product image"  />
	<a href={data.detail}  class="btn btn-lg btn-primary btn-block" role="button" >Sign in </a>
                   
      
            <div className="caption clearfix">
              <h3>{data.name}</h3>
              <div className="product__price">{data.price} {data.currency}</div>
			 
              <div className="product__button-wrap">
                <button onClick={this.addToCart}> Add</button>
				  <button onClick={this.removeToCart}> remove</button>
              </div>
            </div>
          </div>
		  
		  
		   
		  
        );
    }
});

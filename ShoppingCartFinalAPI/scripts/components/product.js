/** @jsx React.DOM */

var Products = React.createClass({
  
    getInitialState: function() {
        return {
            data:[],
            i:0,
          };
    },
   

    componentDidMount: function() {
        var self =this;

        $.ajax({
            url: 'api/Product',
            dataType: 'json',
            type: 'GET',
            contentType: 'application/json',

            data: JSON.stringify( ),
            processData: false,
        
            success: function( data, textStatus, jQxhr ){
                
    
                console.log(data);
             //   console.log(data[1]);

                self.setState({data:data});
          
              
            

            },
            error: function( jqXhr, textStatus, errorThrown ){
                console.log( errorThrown );
        
            }
        });
    },
    addToCart: function(i) {
 
        var x = this.state.data;
        $.publish('cart.added',x[i]);
     
    },

    removeToCart: function(i) {
    
        var x = this.state.data;
        $.publish('cart.removed', x[i].Id);
        

    },
    handleClick: function(i) {
        console.log('You clicked: ' + this.state.data[i]);
    },
    loadComp: function()
    {
       
        var newD= this.state.data;
        var cList = $('ul.mylist')
        $.each(newD, function(i)
        {
            var li = $('<li/>')
                .addClass('ui-menu-item')
                .attr('role', 'menuitem')
                .appendTo(cList);
            var aaa = $('<a/>')
                .addClass('ui-all')
                .text(newD)
                .appendTo(li);
            
            console.log(cList);

        });

    },

    render: function() {
        var self = this;
        var i =0;
        var newD= this.state.data;
        var listItems = newD.map(function(item, i) {

            return (
          <div className="col-xs-6 col-md-4">
             <div className="thumbnail">
              <img src={item.detail} alt="product image"/>

                <div className="caption clearfix">
                  <h3>{item.ProductName}</h3>
                  <div className="product__price">{item.price} {item.currency}</div>
                  <div className="product__button-wrap">
                    <button onClick={self.addToCart.bind(self,i)}> Add</button>
                      <button onClick={self.removeToCart.bind(self,i)}> remove</button>
                  </div>
                </div>
              </div>
                 </div>
            )
                      });

        return (
          <div>
            {listItems}
            </div>
      );

}

});
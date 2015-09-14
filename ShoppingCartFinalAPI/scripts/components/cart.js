/** @jsx React.DOM */

var Cart = React.createClass({

    getInitialState: function() {
      
      $.subscribe('cart.added', this.addItem);
      $.subscribe('cart.removed', this.removeItem);

      return {
         i:0,
        items: [],
        total: 0,
        currency: 'TL'
      };
    },

    addItem: function(e,item) {

/*        var newItems = this.state.items.slice(0);
        newItems.push(this.refs.newItem.state.value);
        this.refs.newItem.setState({value: ""})
        this.setState({item: newItems});
  */     
        var newItems= this.state.items.push(item);
        this.setState({item:newItems});
        this.forceUpdate();
      
       this.countTotal();
    },

    removeItem: function(e,itemId) {
        var itemIndexInArray;
        var self =this;

      this.state.items.some(function(item, index) {
        if(item.id === itemId) {
          itemIndexInArray = index;
          return true;
        }
      });

      this.state.items.splice(itemIndexInArray, 1);
      this.forceUpdate();

      this.countTotal();
    },

    countTotal: function() {
      var total = 0;

      this.state.items.forEach(function(item, index) {
        total += item.price;
      });

      this.setState({
        total: total
      })
    },
	clearAll: function()
	{
	this.state.items.forEach(function(item, index) {
        total =0;
		item.price=0;
      total += item.price;
      });

      this.setState({
        total: total
      })
	},
	orderDetail : function()
	{
	   
        var self =this;
	   
        var item = self.state.items;
        var total= self.state.total ;
        var ItemId = [];
	 
        item.forEach(function(item) {
            
            self.setState({item:item});
          //  ItemId=  item.Id ;
           ItemId.push(item.Id );
            
            console.log(ItemId);
          //  console.log(item);
  
        });

       
	    $.ajax({
	   
	        type: 'GET',
	        traditional: true,
	        contentType: 'application/json; charset=utf-8',
	        url: 'http://localhost:50164/api/Order',
	        // ItemId: [1, 2, 3]
	       // URL:'http://localhost:50164/api/Order/OrderDetail?itemId=3&total=16',
	      //  data:{"ItemId":ItemId, "total":total},
	        data: { 
	               ItemId: ItemId, total:total },
	        //data:"{'ItemId': '" + ItemId + "','total': '" + 80 + "'}",
	        dataType: "json",


	        success: function (item) {
	   
	            console.log('order detail');
	            console.log(item);
	          
	        },
	        error: function (xhr ){
	            alert(xhr.responseText);
	            console.log(item);
	            console.log("errrrrrrrrrrrrr");
               
	        }
	

        });
	},

   render: function() {
       var self=this;
        arr:[];
       var items = this.state.items.map(function(item) {
           var price=item.price;
           var id=item.id;
           var detail=item.detail;
           var name = item.ProductName;
            return (
              <li key={item.id} className="cart-item">
                <span className="cart-item__name">{item.ProductName}</span>
                <span className="cart-item__price">{item.price} {item.currency}</span>
              </li>
            )
        });

        var body = (
          <ul>

            {items}
          </ul>
        );

        var empty = <div className="alert alert-info">empty</div>;

        return (
        
          <div className="panel panel-default">
            <div className="panel-body">
              {items.length > 0 ? body : empty}
              <div className="cart__total">Total: {this.state.total} {this.state.currency}</div>
                
			   <button  onClick={this.clearAll} > Clear All</button>
                     <button  onClick={self.orderDetail} > Order</button>
                 
                
                   </div>
                 


                   </div>
        );
    }
                   });

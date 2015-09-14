/** @jsx React.DOM */
var React = require('react');
var Router = require('react-router');
var { Route, DefaultRoute, RouteHandler, Link } = Router;
var App = React.createClass({
 contextTypes: {
    router: React.PropTypes.func
  },

  render: function () {
      var { Sign in, Need help , Create an account } = this.context.router.getCurrentQuery();
    return (
   <div class="container">
    <div class="pull-right">
        <div class="pull-right">
            
            <div class="pull-right">
            
                <form class="pull-right">
                <input type="text" class="form-control" placeholder="Email" required autofocus>
                <input type="password" class="form-control" placeholder="Password" required>
                <button class="btn btn-lg btn-primary btn-block" type="submit">
                    Sign in</button>
                <a href="#" class="pull-right need-help">Need help </a><span class="clearfix"></span>
				      <a href="#" class="pull-right new-account">Create an account </a>
                </form>
            </div>
			
      
        </div>
    </div>
</div>
    );
  }
});
var Page1 = React.createClass({
  render: function () {
    return (
      <div class="text">
        <h1>Page 1</h1>
        <p>INSIDE PAGE 1 </p>
      </div>
    );
  }
});

var routes = (
  <Route handler={App} path ="/">
    <Route name="PAGE1" handler={Page1} />
   
  </Route>
  
);

Router.run(routes, function (Handler) {
  React.render(<Handler/>, document.getElementById('lpage'));
});

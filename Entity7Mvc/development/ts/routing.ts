/**
 * Created by seymour.h on 05/07/2016.
 */
import {Component} from '@angular/core'
import {Route,RouteConfig,Router,ROUTER_DIRECTIVES} from '@angular/router-deprecated';

import {AppComponent} from './Main/app.component';


@RouteConfig([
    { path: '/AppComponent',as:"AppComponent", component: AppComponent, useAsDefault: true }
])
@Component({
    selector:'routing',
    directives:[ROUTER_DIRECTIVES],
    template: `<div>
	Basic Routing
	<ul>
	  <li><a [routerLink]="['./AppComponent']">AppComponent</a></li>
	 
	</ul>
	<div style="border: 1px solid black">
	  <router-outlet></router-outlet>
	</div>

	`
})
export  class  RoutingComponent{

}

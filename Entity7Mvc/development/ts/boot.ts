/**
 * Created by seymour.h on 04/20/2016.
 */
import {bootstrap} from '@angular/platform-browser-dynamic';
import {AppComponent} from './Main/app.component';

import {Http, HTTP_PROVIDERS} from '@angular/http';
import {Route,RouteConfig,Router,ROUTER_DIRECTIVES,ROUTER_PROVIDERS } from '@angular/router-deprecated';


import {provide} from '@angular/core';
import {RoutingComponent} from './routing';


//bootstrap(AppComponent);

//bootstrap(ColdObservableComponent);//
bootstrap(RoutingComponent,[ROUTER_PROVIDERS]);
//bootstrap(FactoryInjectComponent,[provide('Random',randomDefinition)]);
///
//Router.config([
//    { 'path': '/', 'component': AppComponent },
//    { 'path': '/main/:id', 'component': MainComponent },
//    { 'path': '/Search', 'component': SearchComponent }
//]);
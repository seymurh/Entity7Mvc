System.register(['@angular/core', '@angular/router-deprecated', './Main/app.component'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, router_deprecated_1, app_component_1;
    var RoutingComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_deprecated_1_1) {
                router_deprecated_1 = router_deprecated_1_1;
            },
            function (app_component_1_1) {
                app_component_1 = app_component_1_1;
            }],
        execute: function() {
            RoutingComponent = (function () {
                function RoutingComponent() {
                }
                RoutingComponent = __decorate([
                    router_deprecated_1.RouteConfig([
                        { path: '/AppComponent', as: "AppComponent", component: app_component_1.AppComponent, useAsDefault: true }
                    ]),
                    core_1.Component({
                        selector: 'routing',
                        directives: [router_deprecated_1.ROUTER_DIRECTIVES],
                        template: "<div>\n\tBasic Routing\n\t<ul>\n\t  <li><a [routerLink]=\"['./AppComponent']\">AppComponent</a></li>\n\t \n\t</ul>\n\t<div style=\"border: 1px solid black\">\n\t  <router-outlet></router-outlet>\n\t</div>\n\n\t"
                    }), 
                    __metadata('design:paramtypes', [])
                ], RoutingComponent);
                return RoutingComponent;
            }());
            exports_1("RoutingComponent", RoutingComponent);
        }
    }
});

//# sourceMappingURL=routing.js.map

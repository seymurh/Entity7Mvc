/**
 * Created by seymour.h on 04/20/2016.
 */
//import { ROUTER_PROVIDERS } from '@angular/router';
import {Component} from '@angular/core';
import {FORM_DIRECTIVES} from "@angular/common";
import {FormBuilder} from "@angular/common";
import {Validators} from "@angular/common";
import { RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS } from '@angular/router-deprecated';

interface  Artist{
        Name:String;
        Surname:String;
        Amount:Number;
}

@Component({
        selector:'my-app',
       // templateUrl:'./Home/App',
	   template:`<div class="col-md-8 col-md-offset-2">
    <div>
        <h1>Home Index</h1>
        <h2>{{name}}</h2>
    </div>
    <div *ngIf="artists">
        <h2>List of artists</h2>
        <button type="button" (click)="AddArtist(false)" class="btn btn-success">Add + </button>
        <ul>
            <li *ngFor="#artist of artists">{{artist.Name}} {{artist.Surname}} {{artist.Amount}}
                <button type="button" class="btn btn-danger" (click)="deleteArtist(artist)">delete</button>
                <button type="button" class="btn btn-primary" (click)="updateArtist(artist)" >update</button>
            </li>
        </ul>
    </div>
    <form [ngFormModel]="artist" (ngSubmit)="AddArtist(artist.value)"   id="artistform" *ngIf="openAddArtistForm">
    <!--<form #artist="ngForm" (ngSubmit)="AddArtist(artist.value)"   id="artistform" *ngIf="openAddArtistForm">-->
        <div  class="form-group">
            <label class="control-label">Name</label>
            <input type="text"  ngControl="Name" class="form-control"/>
        </div>
        <div  class="form-group">
            <label class="control-label">Surname</label>
            <input type="text"  ngControl="Surname" class="form-control"/>
        </div>
        <div class="form-group">
            <label class="control-label">Amount</label>
            <input type="number" ngControl="Amount" class="form-control" />
        </div>
        <button type="submit" class="btn btn-primary">Save</button>
    </form>

    <div *ngIf="artist" class="alert-warning">
        <h3>{{artist.Name}} {{artist.Surname}} {{artist.Amount}}</h3>
    </div>
</div>
`,
        directives:[FORM_DIRECTIVES,ROUTER_DIRECTIVES],
        providers:[ROUTER_PROVIDERS]
})
export class AppComponent{
        name:String="binging";
        artists:any;
        artist:any;
       // group:FormBuilder;
        openAddArtistForm:boolean;
        constructor(fb:FormBuilder){

                this.artist=fb.group({
                        Name:[""],
                        Surname:[""],
                        Amount:[""]
                });
                this.name="setted binding from constructor";
                this.artists=[
                        {Name:"Angelina Joolie"},
                        {Name:"Bred Bitt"},
                        {Name:"Silvester Stalone"}
                ];
        }
        AddArtist(artist){
                console.log(artist);
                if (!this.openAddArtistForm){
                        this.openAddArtistForm=true;

                }else if(artist!=null){
                        this.artists.push(artist);
                        this.openAddArtistForm=false;

                      //  artist=null;
                }
        }
        deleteArtist(artist){
                for(var i=0;i<this.artists.length;i++){
                     if(this.artists[i]===artist){
                             this.artists.splice(i,1);
                     }
                }
        }

        updateArtist(artist:Artist){
                if (!this.openAddArtistForm){
                        this.openAddArtistForm=true;
                        this.artist.controls["Name"].updateValue(artist.Name);
                        this.artist.controls["Surname"].updateValue(artist.Surname);
                        this.artist.controls["Amount"].updateValue(artist.Amount);
                        console.log(this.artist);
                }else {
                        this.openAddArtistForm=false;
                }
        }
}


import {Component} from '@angular/core'

@Component({
    selector:'app-server',
    templateUrl:'./server.component.html',
    styles:[`
    .online
    {
        color:White
    }`]
})

export class Servercomponent
{
    ServerId=10;
    Serverstatus:string='Offline';

    constructor() {
        
        this.Serverstatus=Math.random()>0.5 ? 'Online':'Offline'
    }

    getServerStatus()
    {
        return this.Serverstatus;
    }

    getcolor()
    {
        return this.Serverstatus==='Online'?'green':'red';
    }
}
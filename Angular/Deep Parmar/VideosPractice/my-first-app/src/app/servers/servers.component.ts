import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-servers',
  // selector:'[app-servers]',
  // selector:'.app-servers',
  templateUrl: './servers.component.html',
  // template:`
  // <app-server></app-server>
  // <app-server></app-server>`,
  styleUrls: ['./servers.component.css']
})
export class ServersComponent implements OnInit {

  ServerCreationStatus='Server is not created';
  allowCreateServer=false;
  serverStatus='offline';
  CreationStatus=false;
  ServerName='';
  Servers=["Server 1","Server 2"];

  constructor() { 

    setTimeout(() => {
      this.allowCreateServer=true;
    }, 2000);

  }

  ngOnInit(): void {
  }

  CreateServer()
  {
    this.CreationStatus=true;
    this.Servers.push(this.ServerName);
    this.ServerCreationStatus='Server IS Created';
  }

  AddserverName(name:Event)
  {
    this.ServerName=(<HTMLOutputElement>name.target).value;
  }

}

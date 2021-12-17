import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-error',
  template: `<h1>Page not found</h1>
  <p>This is a Error Page</p>
 `
})
export class ErrorComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}

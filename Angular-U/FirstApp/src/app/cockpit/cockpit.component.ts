import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'cockpit',
  templateUrl: './cockpit.component.html',
  styleUrls: ['./cockpit.component.scss']
})
export class CockpitComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  serverAdded(){
    alert('server Added');
  }

  bluePrintAdded(){
    alert('blueprint added');
  }

}

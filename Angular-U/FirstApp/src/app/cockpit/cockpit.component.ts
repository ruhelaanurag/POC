import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-cockpit',
  templateUrl: './cockpit.component.html',
  styleUrls: ['./cockpit.component.scss']
})
export class CockpitComponent implements OnInit {
  @Output() serverEvent = new EventEmitter<string>();
  @Output() bluePrintEvent = new EventEmitter<string>();
  constructor() { }

  ngOnInit(): void {
  }

  serverAdded() {
    this.serverEvent.emit('serverAdded');
    // alert('server Added');
  }

  bluePrintAdded() {
    this.bluePrintEvent.emit('bluePrint Added');
    // alert('blueprint added');
  }

}

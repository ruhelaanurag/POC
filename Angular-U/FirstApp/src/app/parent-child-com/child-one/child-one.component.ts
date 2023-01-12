import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-child-one',
  template: `
<div style="border:solid 1px blue; max-width:200px; min-height:150px">
  child
  <h2>This is the value {{getData}}</h2>
  <br /><br /><br />
  <input type="text" name="txtInputChild" #txtChild value="" /><br />
  <button (click)="buttonClicked(txtChild.value)">Click Me!</button>
</div>
`
})
export class ChildOneComponent implements OnInit {
  @Input() getData = '';
  @Output() setData = new EventEmitter<string>();

  constructor() { }

  ngOnInit(): void {
  }

  buttonClicked(event: string) {
    this.setData.emit(event);
  }

}

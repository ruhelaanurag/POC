import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-parent-one',
  template:`
  <div style="border:solid 1px black; max-width:200px; min-height:150px">
    parent component
    <input type="text" name="getValue" [value]="[(itemValue)]" /><br />
    {{itemValue}} <br /><br />
    <app-child-one [getData]="itemValue" (setData)="setItemValue($event)"></app-child-one>
  </div>
`
})
export class ParentOneComponent implements OnInit {
  public itemValue: string = 'default';

  constructor() { }

  ngOnInit(): void {
  }
  setItemValue(event: string) {
    this.itemValue = event;
  }
}

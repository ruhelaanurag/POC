import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-parent-one',
  templateUrl: './parent-one.component.html',
  styleUrls: ['./parent-one.component.scss']
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

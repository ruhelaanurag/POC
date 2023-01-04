import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-child-one',
  templateUrl: './child-one.component.html',
  styleUrls: ['./child-one.component.scss']
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

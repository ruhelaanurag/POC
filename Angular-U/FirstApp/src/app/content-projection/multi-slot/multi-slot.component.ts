import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-multi-slot',
  template: `
<p>multi-slot content projection!</p>
<div>
  <ng-content> </ng-content><br/>
  <ng-content select="question"></ng-content>
</div>`
})
export class MultiSlotComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}

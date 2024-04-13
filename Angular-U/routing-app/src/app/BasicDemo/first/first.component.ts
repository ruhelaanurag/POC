import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-first',
  templateUrl: './first.component.html',
  styleUrls: ['./first.component.css']
})
export class FirstComponent implements OnInit {
  username$ = this.route.paramMap
  .pipe(
    map((params: ParamMap) => params.get('username'))
  );
  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
  }

}

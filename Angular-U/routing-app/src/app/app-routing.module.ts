import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, UrlSegment } from '@angular/router';
import { FirstComponent } from './BasicDemo/first/first.component';
import { MasterComponent } from './BasicDemo/master/master.component';
import { SecondComponent } from './BasicDemo/second/second.component';
import { CrisisListComponent } from './CrisisDemo/crisis-list/crisis-list.component';
import { HerosListComponent } from './CrisisDemo/heros-list/heros-list.component';
import { CrisissListComponent } from './RouteDemo/crisiss-list/crisiss-list.component';
import { HeroListComponent } from './RouteDemo/hero-list/hero-list.component';


export const routes: Routes=[
  {path:'master', component: MasterComponent},
  {path:'first', component: FirstComponent},
  {path: 'second', component: SecondComponent},
  {path:'crisis-list', component: CrisisListComponent},
  {path: 'hero-list', component: HerosListComponent},
  { path: 'crisiss-center', component: CrisissListComponent },
  { path: 'heroes', component: HeroListComponent },
  {
    matcher: (url) => {
      if (url.length === 1 && url[0].path.match(/^@[\w]+$/gm)) {
        return {
          consumed: url,
          posParams: {
            username: new UrlSegment(url[0].path.slice(1), {})
          }
        };
      }
  
      return null;
    },
    component: FirstComponent
  },
  {path: '*/*', component: MasterComponent}
];


@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class AppRoutingModule { }

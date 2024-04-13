import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { FirstComponent } from './BasicDemo/first/first.component';
import { SecondComponent } from './BasicDemo/second/second.component';
import { MasterComponent } from './BasicDemo/master/master.component';
import { Routes, Router, RouterModule, UrlSegment } from '@angular/router';
import { CrisisListComponent } from './CrisisDemo/crisis-list/crisis-list.component';
import { HerosListComponent } from './CrisisDemo/heros-list/heros-list.component';
import { firstValueFrom } from 'rxjs';
import { BasicrouteComponent } from './CrisisDemo/basicroute/basicroute.component';
import { CrisissListComponent } from './RouteDemo/crisiss-list/crisiss-list.component';
import { HeroListComponent } from './RouteDemo/hero-list/hero-list.component';
import { AppRoutingModule } from './app-routing.module';


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
  declarations: [
    AppComponent,
    FirstComponent,
    SecondComponent,
    MasterComponent,
    CrisisListComponent,
    HerosListComponent,
    BasicrouteComponent,
    HeroListComponent
  ],
  imports: [
    BrowserModule, RouterModule.forRoot(routes), AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

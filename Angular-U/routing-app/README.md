# RoutingApp

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 13.2.2.  

### <u>BasicDemo</u> 
#### This folder contains master, first and second components.  
`MasterComponent:` Contains 2 routerlinks to `first` and `second` component. Contains custom route match, for first component. path: "/master"  
`FirstComponent:` Receives the data from `MasterComponent` for CustomRoute. Mapping regex is defined in `app.module.ts` inside `Routes[]`  
`SecondComponent:` plain basic component.  

### <u>CrisisDemo</u> 
#### This folder contains basicroute, crisis-list and heros-list components.  
`basicroute:` contains routerlink to crisis-list and heros-list. routerlink has angular css property `routerLinkActive`  
`crisis-list:`  plain basic component.  
`heros-list:` plain basic component.  

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via a platform of your choice. To use this command, you need to first add a package that implements end-to-end testing capabilities.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.io/cli) page.

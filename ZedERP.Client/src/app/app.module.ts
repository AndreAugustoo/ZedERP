import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { GroupsComponent } from './components/groups/groups.component';
import { ProductsComponent } from './components/products/products.component';
import { UnitsComponent } from './components/units/units.component';

@NgModule({
  declarations: [
    AppComponent,
    GroupsComponent,
    ProductsComponent,
    UnitsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,

  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

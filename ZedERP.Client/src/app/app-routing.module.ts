import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GroupsComponent } from './components/groups/groups.component';
import { ProductsComponent } from './components/products/products.component';
import { UnitsComponent } from './components/units/units.component';

const routes: Routes = [
  { path: 'groups', component: GroupsComponent },
  { path: 'products', component: ProductsComponent },
  { path: 'units', component: UnitsComponent },
  { path: '', redirectTo: '/groups', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

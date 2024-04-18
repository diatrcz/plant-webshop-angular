import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductDetailsComponent } from './components/product-details/product-details.component';
import { MainPageComponent } from './components/main-page/main-page.component';
import { PlantsListComponent } from './components/plants-list/plants-list.component';
import { SearchListComponent } from './components/search-list/search-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'main', pathMatch: 'full' },
  { path: 'main', component: MainPageComponent },
  { path: 'product/:id', component: ProductDetailsComponent },
  { path: 'shop/:categoryName', component: PlantsListComponent},
  { path: 'search-results', component: SearchListComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

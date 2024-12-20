import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductDetailsComponent } from './components/product-details/product-details.component';
import { MainPageComponent } from './components/main-page/main-page.component';
import { PlantsListComponent } from './components/plants-list/plants-list.component';
import { SearchListComponent } from './components/search-list/search-list.component';
import { ShoppingCartComponent } from './components/shopping-cart/shopping-cart.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { AddProductComponent } from './components/add-product/add-product.component';
import { OrderDetailsComponent } from './components/order-details/order-details.component';
import { OrdersComponent } from './components/orders/orders.component';
import { WishlistComponent } from './components/wishlist/wishlist.component';

const routes: Routes = [
  { path: '', redirectTo: 'main', pathMatch: 'full' },
  { path: 'main', component: MainPageComponent },
  { path: 'product/:id', component: ProductDetailsComponent },
  { path: 'shop/:categoryName', component: PlantsListComponent},
  { path: 'search-results', component: SearchListComponent},
  { path: 'cart', component: ShoppingCartComponent},
  { path: 'login-user', component: LoginComponent},
  { path: 'register-user', component: RegisterComponent},
  { path: 'user-profile', component: UserProfileComponent},
  { path: 'add/:type', component: AddProductComponent},
  { path: 'order/:id', component: OrderDetailsComponent },
  { path: 'orders', component: OrdersComponent},
  { path: 'wishlist', component: WishlistComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

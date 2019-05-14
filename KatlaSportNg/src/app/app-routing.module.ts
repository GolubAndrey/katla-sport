import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainPageComponent } from 'app/main-page/main-page.component';
import { HiveFormComponent } from './hive-management/forms/hive-form.component';
import { HiveSectionFormComponent } from './hive-management/forms/hive-section-form.component';
import { HiveListComponent } from './hive-management/lists/hive-list.component';
import { HiveSectionListComponent } from './hive-management/lists/hive-section-list.component';
import { ProductCategoryFormComponent } from './product-management/forms/product-category-form.component';
import { ProductFormComponent } from './product-management/forms/product-form.component';
import { ProductCategoryListComponent } from './product-management/lists/product-category-list.component';
import { ProductCategoryProductListComponent } from './product-management/lists/product-category-product-list.component';
import { ProductListComponent } from './product-management/lists/product-list.component';
import { HiveSectionProductListComponent} from './product-section-management/lists/hive-section-product-list.component'
import { ProductToSectionRequestListComponent} from './product-section-management/lists/product-section-request-list.component'
import { ProductToSectionRequestFormComponent} from './product-section-management/forms/product-section-request-form.component'
import { UserComponent} from './login-managment/forms/user/user.component'
import { SignInComponent} from './login-managment/forms/user/sign-in/sign-in.component'
import { SignUpComponent} from './login-managment/forms/user/sign-up/sign-up.component'
import { AuthGuard } from './login-managment/auth/auth.guard';
import { HeaderComponent} from './header/header.component'


const routes: Routes = [
  { path: '', component: HeaderComponent, canActivate: [AuthGuard],
    children:[
    { path: 'main', component: MainPageComponent },
    { path: 'categories', component: ProductCategoryListComponent },
    { path: 'category', component: ProductCategoryFormComponent },
    { path: 'category/:id', component: ProductCategoryFormComponent },
    { path: 'category/:id/products', component: ProductCategoryProductListComponent },
    { path: 'products', component: ProductListComponent },
    { path: 'product/:id', component: ProductFormComponent },
    { path: 'category/:categoryId/product/:id', component: ProductFormComponent },
    { path: 'hives', component: HiveListComponent },
    { path: 'hive', component: HiveFormComponent },
    { path: 'hive/:id', component: HiveFormComponent },
    { path: 'hive/:id/sections', component: HiveSectionListComponent },
    { path: 'section/:id', component: HiveSectionFormComponent },
    { path: 'hive/:hiveId/section', component: HiveSectionFormComponent },
    { path: 'section/:hiveId/:id', component: HiveSectionFormComponent },
    { path: 'sectionProducts/:id', component: HiveSectionProductListComponent},
    { path: 'productRequests', component: ProductToSectionRequestListComponent},
    { path: 'productRequests/:hiveSectionId/:productId', component: ProductToSectionRequestFormComponent}]},
  { path: 'login', component: UserComponent,
    children: [{ path: '', component: SignInComponent }]},
  { path: 'signup', component: UserComponent,
    children: [{ path: '', component: SignUpComponent }]},
  { path: '', redirectTo: '/login', pathMatch: 'full' }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }

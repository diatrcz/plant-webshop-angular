import { Component, Input } from '@angular/core';
import { Category } from '../../models/category.type';

@Component({
  selector: 'app-product-list-item',
  templateUrl: './product-list-item.component.html',
  styleUrl: './product-list-item.component.css'
})
export class ProductListItemComponent {
  @Input() name!: string;
  @Input() imageUrl?: string | null;
  @Input() price!: number;
  @Input() category?: string | null;
}

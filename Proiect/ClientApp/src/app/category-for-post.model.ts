import { Category } from './category.model';
import { Post } from './post.model';

export interface CategoryForPost {
  categoryId: string;
  category: Category[];
  postId: string;
  post: Post;
}

import { CategoryForPost } from './category-for-post.model';
import { Comment } from './comment.model';
import { User } from './user.model';

export interface Post {
  id: string;
  title: string;
  content: string;
  imageURL: string;
  categoryForPost: CategoryForPost[] | undefined;
  comments: Comment[] | undefined;
  user: User | undefined;
  userId: string | undefined;
  dateCreated: string | undefined;
  dateModified: string | undefined;
}

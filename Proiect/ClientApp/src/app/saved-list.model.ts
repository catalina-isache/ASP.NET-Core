
import { Post } from './post.model';
import { User } from './user.model';

export interface SavedList {
  userId?: string;
  user?: User;
  posts?: Post[];
}

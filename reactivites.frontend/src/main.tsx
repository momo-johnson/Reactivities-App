import ReactDOM from 'react-dom/client'
import 'semantic-ui-css/semantic.min.css'
import 'react-calendar/dist/Calendar.css'
import './app/layout/styles.css'
import { StoreContext, store } from './app/stores/store.ts'
import { RouterProvider } from 'react-router-dom'
import { router } from './app/router/route.tsx'


ReactDOM.createRoot(document.getElementById('root')!).render(
  <>
    <StoreContext.Provider value={store}>
    <RouterProvider router={router} />
    </StoreContext.Provider>
    </>

)

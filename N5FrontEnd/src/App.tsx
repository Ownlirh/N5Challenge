import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { Suspense, lazy } from 'react';
import { Home } from './pages/Home/Home';

const PermissionsLazy = lazy(() => import('./pages/Permissions/Permissions'));

function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route index element={<Home />} />
                <Route
                    path={'permission/*'}
                    element={
                        <Suspense fallback={<div>Loading...</div>}>
                            <PermissionsLazy />
                        </Suspense>
                    }
                />
            </Routes>
        </BrowserRouter>
    );
}

export default App;

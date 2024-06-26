import { useNavigate } from 'react-router-dom';

export const Home = () => {
    const navigate = useNavigate();

    return (
        <main
            style={{
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center',
            }}
        >
            <h1> Welcome to N5 Web</h1>
            <button onClick={() => navigate('permission')}>
                Go to permissions
            </button>
        </main>
    );
};

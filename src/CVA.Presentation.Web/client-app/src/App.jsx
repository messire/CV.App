import {Box, Container} from '@chakra-ui/react'
import {Route, Routes, Navigate} from 'react-router-dom'

import ProfilesCatalogPage from "./pages/ProfilesCatalogPage.jsx";
import CreateUserPage from "./pages/CreateUserPage.jsx";
import ProfilePage from "./pages/ProfilePage.jsx";
import Navbar from "./components/layout/Navbar.jsx";
import {Toaster} from "./components/ui/toaster.jsx";
import AppBackground from "./components/layout/AppBackground.jsx";
import Footbar from "./components/layout/Footbar.jsx";

function App() {
    return (
        <Box
            minH="100vh"
            minW="320px"
            display="flex"
            flexDirection="column"
            position="relative"
            bg="bg.main"
        >
            <AppBackground/>
            <Container
                maxW="full"
                flex="1"
                display="flex"
                flexDirection="column"
                px={{base: 4, md: 8, lg: 12, xl: 20}}
                py={{base: 4, md: 6, lg: 8}}
                position="relative"
                zIndex={1}
            >
                <Box
                    flex="1"
                    display="flex"
                    flexDirection="column"
                    borderRadius="card"
                    boxShadow="soft"
                    bg="bg.glass"
                    backdropFilter="blur(12px)"
                    border="1px solid"
                    borderColor="border.subtle"
                    overflow="hidden"
                >
                    <Navbar/>
                    <Box flex="1" display="flex" flexDirection="column" overflowY="auto">
                        <Routes>
                            <Route path="/" element={<ProfilesCatalogPage/>}/>
                            <Route path="/u/:id" element={<ProfilePage/>}/>
                            <Route path="/create" element={<CreateUserPage/>}/>
                            <Route path="*" element={<Navigate to="/" replace/>}/>
                        </Routes>
                    </Box>
                    <Footbar/>
                </Box>
            </Container>
            <Toaster/>
        </Box>
    );
}

export default App;
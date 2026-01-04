import {Button, Box, Flex, HStack, Spinner, Text, VStack} from "@chakra-ui/react";
import {useParams} from "react-router-dom";
import {useEffect, useState} from "react";

import {useUserStore} from "../stores/users.store.js";

import ProfileCommon from "../components/profile/ProfileCommon.jsx";
import ProfileContacts from "../components/profile/ProfileContacts.jsx";
import ProfileSkills from "../components/profile/ProfileSkills.jsx";
import ProfileWork from "../components/profile/ProfileWork.jsx";
import ProfilePortfolio from "../components/profile/ProfileProtfolio.jsx";

const ProfilePage = () => {
    const {id} = useParams();

    const fetchUser = useUserStore((state) => state.fetchUser);
    const [user, setUser] = useState(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const loadUser = async () => {
            setLoading(true);
            const result = await fetchUser(id);
            if (result.success) {
                setUser(result.data);
            }
            setLoading(false);
        };
        loadUser();
    }, [id, fetchUser]);

    if (loading) {
        return (
            <VStack py={10}>
                <Spinner size="xl"/>
                <Text>Loading profile...</Text>
            </VStack>
        );
    }

    if (!user) {
        return (
            <VStack py={10}>
                <Text fontSize="xl" color="red.500">User not found</Text>
            </VStack>
        );
    }

    return (
        <VStack gap={6} align="stretch" w="full" p={{base: 4, md: 8, xl: 10}}>
            <HStack 
                w="full" 
                gap={2} 
                overflowX="auto" 
                pb={2}
                css={{
                    '&::-webkit-scrollbar': { display: 'none' },
                    'msOverflowStyle': 'none',
                    'scrollbarWidth': 'none'
                }}
            >
                <Button variant="ghost" color="text.brand" fontWeight="700">Profile</Button>
                <Button variant="ghost" color="text.secondary">Skills</Button>
                <Button variant="ghost" color="text.secondary">Work experience</Button>
                <Button variant="ghost" color="text.secondary">Portfolio</Button>
            </HStack>
            
            <Flex direction={{base: "column", lg: "row"}} gap={6} w="full">
                <Box flex="2">
                    <ProfileCommon user={user}/>
                </Box>
                <Box flex="1">
                    <ProfileContacts user={user}/>
                </Box>
            </Flex>
            
            <ProfileSkills user={user}/>
            <ProfileWork user={user}/>
            <ProfilePortfolio user={user}/>
        </VStack>
    );
}

export default ProfilePage;
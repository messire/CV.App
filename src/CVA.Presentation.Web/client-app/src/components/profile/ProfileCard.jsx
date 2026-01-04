import {Box, VStack, IconButton} from "@chakra-ui/react";
import {Link} from "react-router-dom";

import ProfileCardHeader from "./ProfileCardHeader.jsx";

import { FaUserTie } from "react-icons/fa";

const ProfileCard = ({user}) => {
    return (
        <Box 
             boxShadow="soft"
             borderRadius="card"
             overflow="hidden"
             transition="all 0.3s cubic-bezier(.25,.8,.25,1)"
             w="full"
             minW={0}
             p={{base: 5, md: 6}}
             bg="bg.card"
             border="1px solid"
             borderColor="border.subtle"
             _hover={{
                 transform: "translateY(-8px)", 
                 boxShadow: "cardHover",
                 borderColor: "brand.300"
             }}
        >
            <VStack gap={6} align={'stretch'}>
                <ProfileCardHeader user={user}/>
                <Link to={`/u/${user.id}`}>
                    <IconButton 
                        aria-label="View profile"
                        variant="subtle"
                        colorPalette="indigo"
                        w="full"
                        borderRadius="button"
                        h="12"
                        _hover={{bg: "brand.500", color: "white"}}
                    >
                        <FaUserTie size={18}/>
                        <Box as="span" ml={2} fontWeight="600">
                            View profile
                        </Box>
                    </IconButton>
                </Link>
            </VStack>
        </Box>
    )
};

export default ProfileCard;
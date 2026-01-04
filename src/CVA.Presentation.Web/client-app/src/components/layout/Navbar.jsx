import {Box, Button, Flex, HStack, Text, ClientOnly} from "@chakra-ui/react";
import {Link} from "react-router-dom";

import {useColorMode, useColorModeValue} from "../ui/color-mode.jsx";

import {FaMoon, FaRegFileAlt, FaSun} from "react-icons/fa";

const Navbar = () => {
    const {colorMode, toggleColorMode} = useColorMode();
    const bgButton = useColorModeValue(
        "linear-gradient(135deg, brand.400, brand.600)",
        "linear-gradient(135deg, brand.600, brand.800)"
    );

    return (
        <Box px={{base: 4, md: 6}} py={4} borderBottom="1px solid" borderColor="border.subtle">
            <Flex h={12} alignItems="center" justifyContent="space-between">
                <Link to="/">
                    <HStack gap={3}>
                        <Box
                            w="40px"
                            h="40px"
                            bg={bgButton}
                            borderRadius="12px"
                            display="flex"
                            alignItems="center"
                            justifyContent="center"
                            boxShadow="0 4px 12px rgba(79, 70, 229, 0.3)"
                        >
                            <FaRegFileAlt size={22} color="white"/>
                        </Box>
                        <Text fontWeight="700" fontSize="xl" letterSpacing="-0.03em" color="text.primary">
                            Resume.App
                        </Text>
                    </HStack>
                </Link>
                <HStack gap={4}>
                    <Link to="/create">
                        <Text
                            display={{base: "none", sm: "block"}}
                            color="text.secondary"
                            fontWeight="600"
                            _hover={{color: "text.brand"}}
                            transition="color 0.2s"
                        >
                            Create profile
                        </Text>
                    </Link>
                    <Button
                        variant="ghost"
                        size="sm"
                        onClick={toggleColorMode}
                        borderRadius="full"
                    >
                        <ClientOnly fallback={<FaSun/>}>
                            {colorMode === 'light' ? <FaMoon/> : <FaSun/>}
                        </ClientOnly>
                    </Button>
                </HStack>
            </Flex>
        </Box>
    );
}

export default Navbar;